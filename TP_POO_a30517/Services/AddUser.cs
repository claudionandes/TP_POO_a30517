
//-----------------------------------------------------------------
//    <copyright file="AddUser.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>11-12-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using TP_POO_a30517.Data;
using TP_POO_a30517.Interfaces;
using TP_POO_a30517.LoginUser;

namespace TP_POO_a30517.Services
{
    /// <summary>
    /// Service class for adding new users to the system
    /// </summary>
    public class AddUser : IAddUser
    {
        #region Fields
        private readonly EmergenciesDBContext _context;
        private readonly IPasswordHasher _passwordHasher;
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the AddUser class
        /// </summary>
        /// <param name="context">Database context for user operations</param>
        /// <param name="passwordHasher">Service for hashing passwords</param>

        public AddUser(EmergenciesDBContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Adds a new user to the system
        /// </summary>
        /// <param name="username">The username of the new user</param>
        /// <param name="password">The password of the new user</param>
        /// <exception cref="ArgumentException">Thrown when username or password is empty</exception>
        /// <exception cref="InvalidOperationException">Thrown when the username already exists</exception>
        public void AddUsers (string username, string password)
        {

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Os campos de username e password são obrigatórios.");
            }

            if (_context.Users.Any(u => u.Username == username))
            {
                throw new InvalidOperationException("O username já existe.");
            }

            var passwordHash = _passwordHasher.HashPassword(password);

            var user = new User
            {
                Username = username,
                PasswordHash = passwordHash
            };

            _context.Users.Add(user);
            _context.SaveChanges();
        }
        #endregion
    }
}
