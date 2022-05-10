using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.DB_Entity;

namespace Utils.DB_Utils
{
    public class ItemsUtil
    {
        IndexDbEntities indexDb = new IndexDbEntities();
        public int saveItem(String itemName)
        {
            int termID = isItemExist(itemName);

            if (termID > 0)
            {
                return termID;
            }
            else
            {
                Item item = new Item
                {
                    Item_Name = itemName
                };

                indexDb.Items.Add(item);
                indexDb.SaveChanges();

                return item.Item_Id;
            }
        }

        public int isItemExist(String itemName)
        {
            Item item = indexDb.Items.Where(t => t.Item_Name.Equals(itemName)).SingleOrDefault();

            if (item != null)
            {
                return item.Item_Id;
            }
            else
            {
                return 0;
            }
        }
    }
}
