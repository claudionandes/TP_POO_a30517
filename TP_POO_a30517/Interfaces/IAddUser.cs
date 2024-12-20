
//-----------------------------------------------------------------
//    <copyright file="IAddUser.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>11-12-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

namespace TP_POO_a30517.Interfaces
{
    /// <summary>
    /// Interface for adding users to the system
    /// </summary>
    public interface IAddUser
    {
        #region Methods
        /// <summary>
        /// Adds a new user to the system
        /// </summary>
        /// <param name="username">The username of the new user</param>
        /// <param name="password">The password of the new user</param>
        void AddUsers (string username, string password);
        #endregion
    }
}
