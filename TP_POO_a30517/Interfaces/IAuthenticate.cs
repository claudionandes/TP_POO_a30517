
//-----------------------------------------------------------------
//    <copyright file="IAuthenticate.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>11-12-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using TP_POO_a30517.LoginUser;

namespace TP_POO_a30517.Interfaces
{
    // <summary>
    /// Interface for user authentication
    /// </summary>
    public interface IAuthenticate
    {
        #region Methods

        /// <summary>
        /// Authenticates a user based on username and password
        /// </summary>
        /// <param name="username">The username of the user</param>
        /// <param name="password">The password of the user</param>
        /// <returns>A User object if authentication is successful, null otherwise</returns>
        User Authenticate(string username, string password);
        #endregion
    }
}
