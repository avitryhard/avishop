using System.Collections.Generic;
using System.Linq;

namespace AviShop.Web.Infrastructure.Core
{
    public class PaginationSet<T>
    {
        public int Page { get; set; }

        public int Count
        {
            get
            {
                return (Items != null) ? Items.Count() : 0;
            }
        }

        public IEnumerable<T> Items { get; set; }
        public int TotalPages { get; set; }
        public int MaxPage { get; set; }
        public int TotalCount { get; set; }
    }
}