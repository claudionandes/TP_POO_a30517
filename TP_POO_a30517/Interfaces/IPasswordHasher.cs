
//-----------------------------------------------------------------
//    <copyright file="IPasswordHasher.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>11-12-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

namespace TP_POO_a30517.Interfaces
{
    /// <summary>
    /// Interface for password hashing and verification
    /// </summary>
    public interface IPasswordHasher
    {
        #region Methods

        /// <summary>
        /// Hashes a password
        /// </summary>
        /// <param name="password">The password to hash</param>
        /// <returns>The hashed password</returns>
        string HashPassword(string password);

        /// <summary>
        /// Verifies a password against a hash
        /// </summary>
        /// <param name="password">The password to verify</param>
        /// <param name="hashPassword">The hash to verify against</param>
        /// <returns>True if the password matches the hash, false otherwise</returns>
        bool VerifyPassword(string Password, string hashPassword);
        #endregion
    }
}
