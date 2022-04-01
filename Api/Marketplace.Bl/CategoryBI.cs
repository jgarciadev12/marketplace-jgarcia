using Marketplace.Core.Bl;
using Marketplace.Core.Dal;
using Marketplace.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Bl
{
    public class CategoryBl : ICategoryBl
    {
        #region Fields

        private readonly ICategoryRepository categoryRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryBl"/> class.
        /// </summary>
        /// <param name="categoryRepository">The category repository.</param>
        public CategoryBl(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await this.categoryRepository.GetAllCategoriesAsync().ConfigureAwait(false);
        }

        #endregion
    }
}
