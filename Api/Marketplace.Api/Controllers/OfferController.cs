// <copyright company="ROSEN Swiss AG">
//  Copyright (c) ROSEN Swiss AG
//  This computer program includes confidential, proprietary
//  information and is a trade secret of ROSEN. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of ROSEN. All Rights Reserved.
// </copyright>

namespace Marketplace.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Marketplace.Bl;
    using Marketplace.Core.Bl;
    using Marketplace.Core.Filter;
    using Marketplace.Core.Helpers;
    using Marketplace.Core.Model;
    using Marketplace.Core.Reponses;
    using Marketplace.Core.Request.Queries;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Services for Users
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("[controller]")]
    public class OfferController : ControllerBase
    {
        #region Fields

        private readonly ILogger<OfferController> logger;

        private readonly IOfferBl offerBl;
        private readonly IUriBl uriBl;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="offerBl">The offer business logic.</param>
        public OfferController(ILogger<OfferController> logger, IOfferBl offerBl,IUriBl uriBl)
        {
            this.logger = logger;
            this.offerBl = offerBl;
            this.uriBl = uriBl;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the list of offers.
        /// </summary>
        /// <returns>List of offers</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Offer>>> Get()
        {
            IEnumerable<Offer> result;

            try
            {
                result = await this.offerBl.GetOffersAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.logger?.LogError(ex, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error.");
            }

            return this.Ok(result);
        }

        /// <summary>
        /// Save offer.
        /// </summary>
        /// <returns>new offer</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Offer offer)
        {
            Offer result;

            try
            {
                result = await this.offerBl.SaveOffer(offer).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.logger?.LogError(ex, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error.");
            }

            return this.Ok(result);
        }

        [HttpGet("~/OffersPagination")]
        public async Task<ActionResult<IEnumerable<Offer>>> GetOfferPaginated([FromQuery] PaginationQuery paginationQuery)
        {
            List<Offer> result;

            try
            {
                PaginationFilter paginationFilter = new PaginationFilter() { PageSize = paginationQuery.PageSize, PageNumber = paginationQuery.PageNumber };
                result = await this.offerBl.GetOffersPaginatedAsync(paginationFilter).ConfigureAwait(false);
                foreach (var offer in result)
                {
                    offer.User.Offers = null;
                    offer.Category.Offers = null;
                }
                int totalRecords = await this.offerBl.CountOffers().ConfigureAwait(false);
                var paginationResponse = PaginationHelper.CreatePagePaginationResponse(uriBl,paginationFilter,result,totalRecords);
                return this.Ok(paginationResponse);
            }
            catch (Exception ex)
            {
                this.logger?.LogError(ex, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error.");
            }
        }

        #endregion
    }
}