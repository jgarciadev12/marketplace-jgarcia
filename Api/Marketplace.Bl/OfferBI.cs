using Marketplace.Core.Bl;
using Marketplace.Core.Dal;
using Marketplace.Core.Filter;
using Marketplace.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Bl
{
    public class OfferBl : IOfferBl
    {
        #region Fields

        private readonly IOfferRepository offerRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OfferBl"/> class.
        /// </summary>
        /// <param name="offerRepository">The offer repository.</param>
        public OfferBl(IOfferRepository offerRepository)
        {
            this.offerRepository = offerRepository;
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public async Task<IEnumerable<Offer>> GetOffersAsync()
        {
            return await this.offerRepository.GetAllOffersAsync().ConfigureAwait(false);
        }
        
        public async Task<List<Offer>> GetOffersPaginatedAsync(PaginationFilter paginationFilter)
        {
            return await this.offerRepository.GetAllOffersPaginatedAsync(paginationFilter).ConfigureAwait(false);
        }

        public async Task<Offer> SaveOffer(Offer offer)
        {
            return await this.offerRepository.SaveOffer(offer).ConfigureAwait(false);
        }
        
        public async Task<int> CountOffers()
        {
            return await this.offerRepository.CountOffers().ConfigureAwait(false);
        }

        #endregion
    }
}
