
//-----------------------------------------------------------------
//    <copyright file="UserTests.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>17-12-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using TP_POO_a30517.LoginUser;
using Xunit;

namespace TP_POO_a30517.UnitTests
{
    /// <summary>
    /// Test class for User operations
    /// </summary>
    public class UserTests
    {
        #region User Creation Tests
        /// <summary>
        /// Tests if a user can be created with valid data
        /// </summary>
        [Fact]
        public void CreateUser_WithValidData_CreateUser()
        {
            // Arrange
            string username = "testuser";
            string passwordHash = "hashedpassword123";

            // Act
            var user = new User(username, passwordHash);

            // Assert
            Assert.Equal(username, user.Username);
            Assert.Equal(passwordHash, user.PasswordHash);
        }

        /// <summary>
        /// Tests user creation with an empty username
        /// </summary>
        [Fact]
        public void CreateUser_WithEmptyUsername_()
        {
            // Arrange
            string emptyUsername = "";
            string passwordHash = "hashedpassword123";

            // Act
            var user = new User(emptyUsername, passwordHash);

            // Assert
            Assert.Equal(emptyUsername, user.Username);
            Assert.Equal(passwordHash, user.PasswordHash);
        }

        /// <summary>
        /// Tests user creation with an empty password
        /// </summary>
        [Fact]
        public void CreateUser_WithEmptyPassword()
        {
            // Arrange
            string username = "testuser";
            string emptyPasswordHash = "";

            // Act
            var user = new User(username, emptyPasswordHash);

            // Assert
            Assert.Equal(username, user.Username);
            Assert.Equal(emptyPasswordHash, user.PasswordHash);
        }

        /// <summary>
        /// Tests creation of a user with default values
        /// </summary>
        [Fact]
        public void CreateUserWithDefaultValues()
        {
            // Act
            var user = new User();

            // Assert
            Assert.Null(user.Username);
            Assert.Null(user.PasswordHash);
        }
        #endregion

        #region User Property Tests
        /// <summary>
        /// Tests if user properties can be updated correctly
        /// </summary>
        [Fact]
        public void SetProperties_UpdateValuesCorrectly()
        {
            // Arrange
            var user = new User();

            // Act
            user.Id = 1;
            user.Username = "updateduser";
            user.PasswordHash = "updatedhash";

            // Assert
            Assert.Equal(1, user.Id);
            Assert.Equal("updateduser", user.Username);
            Assert.Equal("updatedhash", user.PasswordHash);
        }
        #endregion
    }
}
