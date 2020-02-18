using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace website_emp
{
    public class Pagination<T>:List<T>
    { 
        public int PageNumber { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }
        public int TotalPages { get; set; }
        public int TotalElements { get; set; }
        public static Pagination<T> Paged(IEnumerable<T> items,int pagenumber ,int pagelength)
        {
            int total = items.Count();
            Pagination<T> pagelist = new Pagination<T>();
            pagelist.TotalPages = 0;
            pagelist.TotalElements = items.Count();
            while (total % 10 != 0)
            {
                pagelist.TotalPages++;
                total = total / 10;
            }
            pagelist.PageNumber = pagenumber;
            if ((pagenumber * pagelength) > items.Count()) pagelist.HasNext = false;
            else { pagelist.HasNext = true; }
            if ((pagenumber==1)) pagelist.HasPrevious= false ;
            else { pagelist.HasPrevious = true; }
            pagelist.AddRange(items.Skip((pagenumber - 1) * pagelength).Take(pagelength));
            return pagelist;
 
        }
    }
}