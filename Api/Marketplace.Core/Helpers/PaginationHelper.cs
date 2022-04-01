using Marketplace.Core.Bl;
using Marketplace.Core.Filter;
using Marketplace.Core.Model;
using Marketplace.Core.Reponses;
using Marketplace.Core.Request.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Core.Helpers
{
    public class PaginationHelper
    {
        public static PagedResponse<T> CreatePagePaginationResponse<T>(IUriBl uriBl, PaginationFilter paginationFilter, List<T> result, int totalRecords)
        {
            var nextPage =
                paginationFilter.PageNumber >= 1
                ? uriBl.GetAllOffersUri(new PaginationQuery(paginationFilter.PageNumber + 1, paginationFilter.PageSize))
                : null;

            var previousPage =
                paginationFilter.PageNumber - 1 >= 1 
                ? uriBl.GetAllOffersUri(new PaginationQuery(paginationFilter.PageNumber - 1, paginationFilter.PageSize))
                : null;

            var paginationReponse = new PagedResponse<T>
            {
                Data = result,
                PageNumber = paginationFilter.PageNumber >= 1 ? paginationFilter.PageNumber : (int?)null,
                PageSize = paginationFilter.PageSize >= 1 ? paginationFilter.PageSize : (int?)null,
                NextPage = result.Any() ? nextPage.ToString():null,
                PreviosPage = previousPage == null ? null : previousPage.ToString(),
                TotalPages = totalRecords
            };

            return paginationReponse;
        }
    }
}
