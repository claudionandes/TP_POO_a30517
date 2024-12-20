
//-----------------------------------------------------------------
//    <copyright file="PasswordHasher.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>11-12-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using System.Text;
using System.Security.Cryptography;
using TP_POO_a30517.Interfaces;

namespace TP_POO_a30517.LoginUser
{
    /// <summary>
    /// Implements password hashing and verification using SHA256
    /// </summary>
    public class PasswordHasher : IPasswordHasher
    {
        #region Public Methods

        /// <summary>
        /// Hashes a password using SHA256
        /// </summary>
        /// <param name="password">The password to hash</param>
        /// <returns>The hashed password as a Base64 string</returns>
        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        /// <summary>
        /// Verifies a password against a hash
        /// </summary>
        /// <param name="password">The password to verify</param>
        /// <param name="hashPassword">The hash to verify against</param>
        /// <returns>True if the password matches the hash, false otherwise</returns>
        public bool VerifyPassword(string password, string hashPassword)
        {
            var hashedInput = HashPassword(password);
            return hashedInput == hashPassword;
        }
        #endregion
    }
}
