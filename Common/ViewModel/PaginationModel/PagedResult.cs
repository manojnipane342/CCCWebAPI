using System;
using System.Collections.Generic;
using System.Text;

namespace Common.ViewModels.PaginationModel
{
    public class PagedResult<T> : PagedResultBase where T : class
    {
        public IList<T> Results { get; set; }

        public PagedResult()
        {
            Results = new List<T>();
        }

        public int TotalRecords { get; set; }
    }

}
