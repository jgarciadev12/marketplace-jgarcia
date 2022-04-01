using Marketplace.Core.Bl;
using Marketplace.Core.Request.Queries;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Bl
{
    public class UriBl : IUriBl
    {
        private readonly string _baseUri;

        public UriBl(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetAllOffersUri(PaginationQuery paginationQuery = null)
        {
            var uri = new Uri(_baseUri);
            if (paginationQuery == null)
                return uri;

            var modifiedUri = QueryHelpers.AddQueryString(_baseUri, "pageNumber", paginationQuery.PageNumber.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "pageSize", paginationQuery.PageSize.ToString());

            return new Uri(modifiedUri);
        }


    }
}
