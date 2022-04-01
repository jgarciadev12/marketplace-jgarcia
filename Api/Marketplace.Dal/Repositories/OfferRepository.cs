// <copyright company="ROSEN Swiss AG">
//  Copyright (c) ROSEN Swiss AG
//  This computer program includes confidential, proprietary
//  information and is a trade secret of ROSEN. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of ROSEN. All Rights Reserved.
// </copyright>

namespace Marketplace.Dal.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Marketplace.Core.Dal;
    using Marketplace.Core.Filter;
    using Marketplace.Core.Model;
    using Microsoft.EntityFrameworkCore;

    public class OfferRepository : IOfferRepository
    {
        #region Fields

        private MarketplaceContext context;

        #endregion

        #region Constructors

        public OfferRepository()
        {
            this.context = new MarketplaceContext();
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public async Task<Offer[]> GetAllOffersAsync()
        {
            return await this.context.Offers.ToArrayAsync();
        }
        //https://www.youtube.com/watch?v=cKj6U4qDmgQ&ab_channel=NickChapsas
        public async Task<List<Offer>> GetAllOffersPaginatedAsync(PaginationFilter paginationFilter)
        {
            return await context.Offers
                        .Skip((paginationFilter.PageNumber - 1) * paginationFilter.PageSize)
                        .Take(paginationFilter.PageSize)
                        .Include(o => o.User)
                        .Include(o => o.Category)
                        .AsNoTracking()
                        .ToListAsync();
        }

        public async Task<Offer> SaveOffer(Offer offer)
        {
            context.Offers.Add(offer);
            await context.SaveChangesAsync();
            return offer;
        }

        public async Task<int> CountOffers()
        {
            return await context.Offers.CountAsync();
        }

        #endregion
    }
}