using Marketplace.Core.Filter;
using Marketplace.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Core.Dal
{
    public interface IOfferRepository
    {
        #region Methods

        /// <summary>
        /// Gets all offers asynchronous.
        /// </summary>
        /// <returns>Array of offers</returns>
        Task<Offer[]> GetAllOffersAsync();


        /// <summary>
        /// Gets all offers paginated asynchronous.
        /// </summary>
        /// <returns>Array of offers</returns>
        Task<List<Offer>> GetAllOffersPaginatedAsync(PaginationFilter paginationFilter);

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
