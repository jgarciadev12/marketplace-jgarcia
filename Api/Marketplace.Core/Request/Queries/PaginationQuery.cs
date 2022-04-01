using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Core.Request.Queries
{
    public class PaginationQuery
    {
        public PaginationQuery()
        {
            PageSize = 10;
            PageNumber = 1;
        }
        public PaginationQuery(int pageNumber,int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
