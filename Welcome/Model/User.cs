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
        private string facultyNumber;
        private string email;

        private char key = 'K'; // XOR криптиране/декриптиране

        private string EncryptDecrypt(string input)
        {
            var output = new char[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                output[i] = (char)(input[i] ^ key);
            }
            return new string(output);
        }

        public string Names { get { return names; } 
            
            set {
                var namesToUpperCase = value.ToUpper();
                names = namesToUpperCase; 
            } }

        public string Password
        {
            get { return EncryptDecrypt(password); } 
            set { password = EncryptDecrypt(value); } 
        }
        public UserRolesEnum Role  { get { return role; } set { role = value; } }

        public string FacultyNumber { get { return facultyNumber; } set { facultyNumber = value; } }
        public string Email { get { return email; } set { email = value; } }
    }
}
