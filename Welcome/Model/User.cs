using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;

namespace Welcome.Model
{
    public class User
    {
        private string names;
        private string password;
        private UserRolesEnum role;

        public string Names { get { return names; } 
            
            set {
                var namesToUpperCase = value.ToUpper();
                names = namesToUpperCase; 
            } }
        public string Password  { get { return password; } set { password = value; } }
        public UserRolesEnum Role  { get { return role; } set { role = value; } }
    }
}
