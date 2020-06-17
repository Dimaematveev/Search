using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search.Console
{
    class Count1
    {
        

        public  int ItemSearch { get;}
        public int IndexItem { get;}
        public int CountCompare { get; }

        public Count1(int itemSearch, int indexItem, int countCompare)
        {
            ItemSearch = itemSearch;
            IndexItem = indexItem;
            CountCompare = countCompare;
        }

    }
}
