
//-----------------------------------------------------------------
//    <copyright file="LoginValidation.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date></date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

namespace LoginLibrary
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }
    }

    public static class AuthManager
    {
        private static List<User> users = new List<User>();

        public static void RegisterUser(string username, string password)
        {
            users.Add(new User { Username = username, Password = password, Roles = new List<string>() });
        }

        public static bool AuthenticateUser(string username, string password)
        {
            var user = users.Find(u => u.Username == username);
            return user != null && user.Password == password;
        }
    }
}
