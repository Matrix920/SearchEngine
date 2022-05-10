using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.DB_Entity;

namespace Utils.DB_Utils
{
    
    public class DocumentsUtil
    {
        IndexDbEntities indexDb = new IndexDbEntities();

        public int saveDocument(String documentName,String documentText)
        {
            Document document = new Document
            {
                Ducument_Name=documentName,
                Document_Text=documentText
            };

            indexDb.Documents.Add(document);
            indexDb.SaveChanges();

            return document.Document_Id;
        }

        public List<int> getDocumentsIds()
        {
            return indexDb.Documents.Select(d => d.Document_Id).ToList();
        }

        public List<Document> getDocumentsByIds(List<int> documentsIds)
        {
            List<Document> documents = new List<Document>();

            foreach(int documentId in documentsIds)
            {
                Document document = indexDb.Documents.Find(documentId);
                documents.Add(document);
            }

            return documents;
        }
    }
}
