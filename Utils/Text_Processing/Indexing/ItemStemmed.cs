using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Text_Processing.Indexing
{
    public class ItemStemmed
    {
        public ItemStemmed(String item,String stemmed)
        {
            this.item = item;
            this.stemmed = stemmed;
        }

        public String item
        {
            set;
            get;
        }

        public String stemmed
        {
            set;
            get;
        }
    }
}
