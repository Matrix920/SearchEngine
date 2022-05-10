using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.DB_Entity;
using Utils.DB_Utils;
using Utils.Text_Processing.Indexing;

namespace Utils.Text_Processing.Quering
{
    public class ExprEvaluation
    {
        private static readonly char CLOSE_BRACKET = ')';
        private static readonly char OPEN_BRACKET = '(';
        private static readonly char SPACE = ' ';
        private static readonly char NOT = '!';
        private static readonly char AND = '&';
        private static readonly char OR = '|';

        char[] tokens;

        DocumentsUtil docUtil = new DocumentsUtil();

        // Stack for Operators
        Stack<Char> operators = new Stack<Char>();

        // stack for items contains documents' Ids of Items
        Stack<List<int>> itemsDocmentIds = new Stack<List<int>>();

        private readonly List<Char> tokenOperators = new List<char> { CLOSE_BRACKET,OPEN_BRACKET,NOT,AND,OR };

        public List<Document> evaluate(String exp)
        {
            tokens = exp.ToCharArray();

            for (int i = 0; i < tokens.Count(); i++)
            {
                if (tokens[i] == SPACE)
                    continue;

                if (! tokenOperators.Contains(tokens[i]))
                {
                    StringBuilder s = new StringBuilder("");

                    while (i < tokens.Count() && !tokenOperators.Contains(tokens[i]))
                        s.Append(tokens[i++]);

                    pushItem(s,false);
                    i--;

                }
                else if (tokens[i] == OPEN_BRACKET)
                {
                    operators.Push(tokens[i]);

                }
                else if (tokens[i] == NOT)
                {
                    StringBuilder s = new StringBuilder("");

                    i++;
                    while (i < tokens.Count() && !tokenOperators.Contains(tokens[i]))
                        s.Append(tokens[i++]);

                    pushItem(s,true);
                    i--;

                }
                else if (tokens[i] == CLOSE_BRACKET)
                {
                    while (operators.Peek() != OPEN_BRACKET)
                        itemsDocmentIds.Push(valueOf(operators.Pop(), itemsDocmentIds.Pop(), itemsDocmentIds.Pop()));

                    operators.Pop();

                }
                else if (tokens[i] == AND || tokens[i] == OR)
                {
                    while ((operators.Count != 0) && hasPrecedence(tokens[i], operators.Peek()))
                        itemsDocmentIds.Push(valueOf(operators.Pop(), itemsDocmentIds.Pop(), itemsDocmentIds.Pop()));

                    operators.Push(tokens[i]);
                }
            
            }

            while (operators.Count != 0)
                itemsDocmentIds.Push(valueOf(operators.Pop(), itemsDocmentIds.Pop(), itemsDocmentIds.Pop()));

            List<int>documentsIds= itemsDocmentIds.Pop();
            List<Document> documents = docUtil.getDocumentsByIds(documentsIds);

            return documents;
        }

        private void pushItem(StringBuilder s,bool isNot)
        {
            String token = s.ToString();
            List<int> itemDocmentIds = getDocumentsList(token);

            if (isNot)
            {
                itemsDocmentIds.Push(valueOfNot(itemDocmentIds));               
            }
            else
            {
                itemsDocmentIds.Push(itemDocmentIds);
            }
        }
        /*
        private void pushItem(StringBuilder s)
        {
            String token = s.ToString();
            List<int> itemDocmentIds = getDocumentsList(token);
            itemsDocmentIds.Push(itemDocmentIds);
        }
        */
        public List<int> getDocumentsList(string token)
        {
            PorterStemmer stemmer = new PorterStemmer();
            ItemsWithDocumentsUtil itmDocUtil = new ItemsWithDocumentsUtil();

            String itemName = stemmer.stemTerm(token.Trim());
            List<int> documentsList = itmDocUtil.getDocumentsList(itemName);
            return documentsList;
        }
        

        public bool hasPrecedence(char op1, char op2)
        {
            if (op2 == OPEN_BRACKET || op2 == CLOSE_BRACKET)
                return false;
            if ((op1 == AND) || (op2 ==OR))
                return false;

            return true;
        }
        

        private List<int> valueOf( char op, List<int> a, List<int> b)
        {
            if (op == AND)
            {
                return a.Intersect(b).ToList();
            }
            else if (op == OR)
            {
                return a.Union(b).ToList();
            }
            else
            {
                return null;
            }

        }

        public List<int> valueOfNot(List<int> b)
        {
            DocumentsUtil doc = new DocumentsUtil();
            List<int> a = doc.getDocumentsIds();

            List<int> result = new List<int>();

            int i = 0, j = 0;
            while (i < a.Count() && j < b.Count())
            {
                if (a[i] == b[j])
                {
                    i++;
                    j++;
                }
                else if (a[i] < b[j])
                {
                    result.Add(a[i]);
                    i++;
                }
                else
                {
                    j++;
                }
            }
            while (i < a.Count())
            {
                result.Add(a[i]);
                i++;
            }

            return result;
        }
    }
}
