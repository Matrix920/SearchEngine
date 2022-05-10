using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Utils.DB_Entity;
using Utils.Text_Processing.Indexing;
using Utils.Text_Processing.Quering;

namespace AIR_Website
{
    public partial class Default : System.Web.UI.Page
    {
        TextIndexing indexing = new TextIndexing();
        ExprEvaluation expEval = new ExprEvaluation();
        protected void Page_Load(object sender, EventArgs e)
        {
           
        
        }



        private void viewIndexResult(List<ItemStemmed> itemsStemmed)
        {
            if (itemsStemmed.Count > 0)
            {
                StringBuilder sb = new StringBuilder("");
                sb.Append("<table>");
                sb.Append("<tr>");

                sb.Append("<th>");
                sb.Append("Item");
                sb.Append("</th>");

                sb.Append("<th>");
                sb.Append("Stemmed");
                sb.Append("</tr>");
                foreach (ItemStemmed itemStemmed in itemsStemmed)
                {
                    sb.Append("<tr>");

                    sb.Append("<td>");
                    sb.Append(itemStemmed.item);
                    sb.Append("</td>");

                    sb.Append("<td>");
                    sb.Append(itemStemmed.stemmed);
                    sb.Append("</td>");

                    sb.Append("</tr>");
                }
                sb.Append("</table>");

                literalIndexResult.Text = sb.ToString();
            }
            else
            {
                literalIndexResult.Text = "No items Indexed";
            }
        }

        private void viewDocuments(List<Document> documents)
        {
            if (documents.Count > 0)
            {
                StringBuilder sb = new StringBuilder("");
                sb.Append("<table>");
                sb.Append("<tr>");

                sb.Append("<th>");
                sb.Append("Document Name");
                sb.Append("</th>");

                sb.Append("<th>");
                sb.Append("Text");
                sb.Append("</tr>");
                foreach (Document document in documents)
                {
                    sb.Append("<tr>");

                    sb.Append("<td>");
                    sb.Append(document.Ducument_Name);
                    sb.Append("</td>");

                    sb.Append("<td>");
                    sb.Append(document.Document_Text);
                    sb.Append("</td>");

                    sb.Append("</tr>");
                }
                sb.Append("</table>");
                literalSearchResult.Text = sb.ToString();
            }
            else
            {
                literalSearchResult.Text = "No result matches";
            }

            
        }

        protected void btnIndex_Click(object sender, EventArgs e)
        {
            if (!(isEmpty(input_docName)||isEmpty(input_docText))){
                String documantName = input_docName.Value;
                String documentText = input_docText.Value;

                List<ItemStemmed> itemsStemmed = indexing.index(documantName, documentText);
                viewIndexResult(itemsStemmed);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (!isEmpty(txtSearch))
            {
                String searchText = txtSearch.Value;
                List<Document> documents = expEval.evaluate(searchText);
                viewDocuments(documents);
            }
        }

        private bool isEmpty(HtmlInputText inputText)
        {
            if(String.IsNullOrWhiteSpace(inputText.Value) || String.IsNullOrEmpty(inputText.Value))
            {
                return true;
            }
            return false;
        }

     
  

    }
    
    
}