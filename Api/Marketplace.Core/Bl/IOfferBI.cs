using Marketplace.Core.Filter;
using Marketplace.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Core.Bl
{
    public interface IOfferBl
    {
        #region Methods

        /// <summary>
        /// Gets offers.
        /// </summary>
        /// <returns>List of offers.</returns>
        Task<IEnumerable<Offer>> GetOffersAsync();
        
        /// <summary>
        /// Gets offers paginated.
        /// </summary>
        /// <returns>List of offers.</returns>
        Task<List<Offer>> GetOffersPaginatedAsync(PaginationFilter paginationFilter);

        /// <summary>
        /// save offer.
        /// </summary>
        /// <param name="offer">offer new.</param> 
        /// <returns>new offer</returns>
        Task<Offer> SaveOffer(Offer offer);
        Task<int> CountOffers();
        
        #endregion
    }
}
