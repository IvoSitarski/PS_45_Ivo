using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;

namespace WelcomeExtended.Helpers
{
    public static class UserHelper
    {
        public static string ToString(User user)
        {
            return "User: "+user.Names + "Role: "+user.Role+ "Email: "+user.Email;
        }

        public static bool ValidateCredentials(this IEnumerable<User> users, string name, string password)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("The name cannot be empty");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("The password cannot be empty");
            }

            return users.Any(u => u.Names.Equals(name) && u.Password.Equals(password));
        }

        public static User GetUser(this IEnumerable<User> users, string name, string password)
        {
            if (!users.ValidateCredentials(name, password))
            {
                throw new UnauthorizedAccessException("Invalid username or password.");
            }

            return users.FirstOrDefault(u => u.Names.Equals(name) && u.Password.Equals(password));
        }
    }
}
