using Marketplace.Core.Request.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Core.Bl
{
    public interface IUriBl
    {
        public Uri GetAllOffersUri(PaginationQuery paginationQuery = null);
    }
}
