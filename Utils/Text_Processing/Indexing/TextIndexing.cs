using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.DB_Utils;

namespace Utils.Text_Processing.Indexing
{
    public class TextIndexing
    {
        public List<ItemStemmed> index(String documentName,String documentText)
        {
            //process text and get tokens without stopped words
            List<String> tokens = getTokens(documentText);

            DocumentsUtil documentsUtils = new DocumentsUtil();
            PorterStemmer stemmer = new PorterStemmer();
            ItemsUtil itemsUtils = new ItemsUtil();
            ItemsWithDocumentsUtil itmsDocsUtils = new ItemsWithDocumentsUtil();

            //result : list of tokens with its stemmed items
            List<ItemStemmed> itemsStemmed = new List<ItemStemmed>();

            //save documentName to database in Documents table
            int documentId = documentsUtils.saveDocument(documentName,documentText);

            foreach (String token in tokens)
            {
                String itemName = stemmer.stemTerm(token);
                if (itemName.Length > 1)
                {
                    //add to database
                    itmsDocsUtils.addItem(itemName, documentId);
                    itemsStemmed.Add(new ItemStemmed(token, itemName));     
                }
            }

            return itemsStemmed;

        }

        public List<String> getTokens(String text)
        {
            List<String> tokens = new List<String>();

            StopWords stopWords = new StopWords();

            string tokenText = "";
            for (int l = 0; l < text.Length; l++)
            {
                if (char.IsLetter(text, l))
                    tokenText += text[l].ToString();
                else
                    tokenText += " ";
            }

            tokenText = tokenText.Trim();
            string[] R = tokenText.Split(' ');
            for (int j = 0; j < R.Length; j++)
            {
                string token = stopWords.remove(R[j]);
                if (token.Length > 1)
                {
                    tokens.Add(token);
                }

            }

            return tokens;
        }
    }
}
