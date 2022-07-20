using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    public class PagnationHelper<T>
    {
        private IList<T> _collection;
        private int _itemsPerPage;
        public PagnationHelper(IList<T> collection, int itemsPerPage)
        {
            _collection = collection;
            _itemsPerPage = itemsPerPage;
        }

        public int ItemCount
        {
            get
            {
                return _collection.Count;
            }
        }

        public int PageCount
        {
            get
            {
                return (int)Math.Ceiling(_collection.Count / Convert.ToDecimal(_itemsPerPage));
            }
        }

        public int PageItemCount(int pageIndex)
        {
            if (pageIndex >= PageCount || pageIndex < 0)
                return -1;

            return _collection.Skip(pageIndex * _itemsPerPage).Take(_itemsPerPage).Count();
        }

        public int PageIndex(int itemIndex)
        {
            if (itemIndex >= ItemCount || itemIndex < 0)
                return -1;

            return itemIndex / _itemsPerPage;
        }
    }
}
