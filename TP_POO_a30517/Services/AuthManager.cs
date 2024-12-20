
//-----------------------------------------------------------------
//    <copyright file="AuthManager.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>23-11-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using TP_POO_a30517.Data;
using TP_POO_a30517.Interfaces;
using TP_POO_a30517.LoginUser;

namespace TP_POO_a30517.Services
{
    /// <summary>
    /// Manages user authentication
    /// </summary>
    public class AuthManager : IAuthenticate
    {
        #region Fields
        private readonly EmergenciesDBContext _context;
        private readonly IPasswordHasher _passwordHasher;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the AuthManager class
        /// </summary>
        /// <param name="context">The database context</param>
        /// <param name="passwordHasher">The password hashing service</param>
        public AuthManager(EmergenciesDBContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Authenticates a user based on username and password
        /// </summary>
        /// <param name="username">The username of the user</param>
        /// <param name="password">The password of the user</param>
        /// <returns>A User object if authentication is successful, null otherwise</returns>
        public User Authenticate(string username, string password)
        {
            var user = _context.Users.SingleOrDefault(u => u.Username == username);
            if (user == null || !_passwordHasher.VerifyPassword(password, user.PasswordHash))
            {
                return null;
            }

            var userModel = new User(user.Username, user.PasswordHash);
            return userModel;
        }
        #endregion
    }
}
