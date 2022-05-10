using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.DB_Entity;

namespace Utils.DB_Utils
{
    public class ItemsWithDocumentsUtil
    {
        IndexDbEntities indexDb = new IndexDbEntities();
        ItemsUtil itemUtil = new ItemsUtil();

        public void addItem(String itemName,int documentId)
        {
            int itemId = itemUtil.saveItem(itemName);

            saveItemWithDocument(documentId, itemId);
        }

        public void saveItemWithDocument(int documentId, int itemId)
        {
            if (!isItemWithDocumentExist(documentId, itemId))
            {
                indexDb.ItemsWithDocuments.Add(new ItemsWithDocument
                {
                    Document_Id = documentId,
                    Item_Id = itemId
                });

                indexDb.SaveChanges();
            }
        }

        public bool isItemWithDocumentExist(int documentId, int itemId)
        {
            ItemsWithDocument itemWithDocument = indexDb.ItemsWithDocuments.Where(x => x.Document_Id == documentId && x.Item_Id == itemId).SingleOrDefault();

            if (itemWithDocument == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<int> getDocumentsList(string itemName)
        {
            List<ItemsWithDocument> itemsWithDocuments = indexDb.ItemsWithDocuments.Where(x => x.Item.Item_Name.Equals(itemName)).ToList();
            List<int> documentsList = itemsWithDocuments.Select(x => x.Document_Id).ToList();
            return documentsList;
        }
    }
}
