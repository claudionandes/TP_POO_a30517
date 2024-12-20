
//-----------------------------------------------------------------
//    <copyright file="User.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>23/11/2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

namespace TP_POO_a30517.LoginUser
{
    /// <summary>
    /// Represents a user in the system
    /// </summary>
    public class User
    {
        #region Properties

        /// <summary>
        /// Gets or sets the unique identifier for the user
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the username of the user
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the hashed password of the user
        /// </summary>
        public string PasswordHash { get; set; }
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the User class with specified username and password hash
        /// </summary>
        /// <param name="username">The username of the user</param>
        /// <param name="passwordHash">The hashed password of the user</param>
        public User(string username, string passwordHash)
        {
            Username = username;
            PasswordHash = passwordHash;

        }

        /// <summary>
        /// Initializes a new instance of the User class
        /// </summary>
        public User() { }
        #endregion
    }
}
