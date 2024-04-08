using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using Welcome.Others;

namespace WelcomeExtended.Data
{
    public class UserData
    {
        private List<User> _users;
        private int _nextId;
        public UserData()
        {
            _nextId = 0;
            _users = new List<User>();
        }

        public void addUser(User user)
        {
            user.Id = _nextId++;
            _users.Add(user);
        }

        public void deleteUser(User user)
        {
            _users.Remove(user);
        }

        public bool ValidateUser(string name, string password)
        {
            foreach (var user in _users)
            {
                if (user.Names == name && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ValidateUserLambda(string name, string password)
        {
            return _users.Where(x => x.Names == name && x.Password == password)
                .FirstOrDefault() != null ? true : false;
        }

        public bool ValidateUserLinq(string name, string password)
        {
            var ret = from user in _users
                      where user.Names == name && user.Password == password
                      select user.Id;

            return ret != null ? true : false;
        }

        // Метод за вземане на потребител по име
        public User GetUser(string name, string password)
        {
            User user = new User();

            string encryptedPassword = user.EncryptDecrypt(password);
            
            return _users.FirstOrDefault(u => u.Names.Equals(name, StringComparison.OrdinalIgnoreCase)
                                              && u.Password.Equals(encryptedPassword));
        }

        public void AssignUserRole(string name, string password, UserRolesEnum role)
        {
            var user = GetUser(name, password);
            if (user != null)
            {
                user.Role = role;
            }
            else
            {
                throw new Exception($"User with name {name} not found.");
            }
        }

        public void SetActive(string name, string password, DateTime expires)
        {
            var user = GetUser(name, password);
            if (user != null)
            {
                 user.IsActive = true;
                 user.Expires = expires;
            }
            else
            {
                throw new Exception($"User with name {name} not found.");
            }
        }
    }
}
