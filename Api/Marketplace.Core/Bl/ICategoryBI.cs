using Marketplace.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Core.Bl
{
    public interface ICategoryBl
    {
        #region Methods

        /// <summary>
        /// Gets categories.
        /// </summary>
        /// <returns>LIst of categories</returns>
        Task<IEnumerable<Category>> GetCategoriesAsync();

        #endregion
    }
}
