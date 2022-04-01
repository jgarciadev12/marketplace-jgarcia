using Marketplace.Core.Dal;
using Marketplace.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Dal.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        #region Fields

        private MarketplaceContext context;

        #endregion

        #region Constructors
        public CategoryRepository()
        {
            this.context = new MarketplaceContext();
        }
        #endregion

        public async Task<Category[]> GetAllCategoriesAsync()
        {
            return await this.context.Categories.ToArrayAsync();
        }
    }
}
