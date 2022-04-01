using Marketplace.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Core.Dal
{
    public interface ICategoryRepository
    {
        #region Methods

        /// <summary>
        /// Gets all categories asynchronous.
        /// </summary>
        /// <returns>Array of categories</returns>
        Task<Category[]> GetAllCategoriesAsync();

        #endregion
    }
}
