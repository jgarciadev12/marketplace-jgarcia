// <copyright company="ROSEN Swiss AG">
//  Copyright (c) ROSEN Swiss AG
//  This computer program includes confidential, proprietary
//  information and is a trade secret of ROSEN. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of ROSEN. All Rights Reserved.
// </copyright>

namespace Marketplace.Core.Bl
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Marketplace.Core.Model;

    /// <summary>
    /// Contract for the User logic
    /// </summary>
    public interface IUserBl
    {
        #region Methods

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns>LIst of users</returns>
        Task<IEnumerable<User>> GetUsersAsync();

        /// <summary>
        /// Save user.
        /// </summary>
        /// <param name="user">user new.</param> 
        /// <returns>new user</returns>
        Task<User> SaveUser(User user);

        /// <summary>
        /// Get user by username.
        /// </summary>
        /// <param name="username">username to return </param> 
        /// <returns>user</returns>
        Task<User> GetUserByUsername(string username);

        #endregion
    }
}