using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using Welcome.Others;
using Welcome.ViewModel;

namespace Welcome.View
{
    public class UserView
    {
        private UserViewModel _viewModel;

        public UserView(UserViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void Display()
        {
            Console.WriteLine("Welcome");
            Console.WriteLine("User: " + _viewModel.Name);
            Console.WriteLine("Role: " + _viewModel.userRolesEnum);
            Console.WriteLine("\n");
        }

        public void DisplayDetailed()
        {
            Console.WriteLine("Welcome to the Detailed View");
            Console.WriteLine($"User: {_viewModel.Name}");
            Console.WriteLine($"Role: {_viewModel.userRolesEnum.ToString()}");
            Console.WriteLine($"Faculty Number: {_viewModel.FacultyNumber}");
            Console.WriteLine($"Email: {_viewModel.Email}");
            Console.WriteLine("Here, you can see all the detailed information about the user.");
            Console.WriteLine("\n");
        }
        public void DisplayTable()
        {
            Console.WriteLine("+-----------------------------------------------+");
            Console.WriteLine("|                User Information               |");
            Console.WriteLine("+----------------------+------------------------+");
            Console.WriteLine(String.Format("| {0, -20} | {1, -24} |", "Field", "Value"));
            Console.WriteLine("+----------------------+------------------------+");
            Console.WriteLine(String.Format("| {0, -20} | {1, -24} |", "Name", _viewModel.Name));
            Console.WriteLine(String.Format("| {0, -20} | {1, -24} |", "Role", _viewModel.userRolesEnum));
            Console.WriteLine(String.Format("| {0, -20} | {1, -24} |", "Faculty Number", _viewModel.FacultyNumber));
            Console.WriteLine(String.Format("| {0, -20} | {1, -24} |", "Email", _viewModel.Email));
            Console.WriteLine("+----------------------+------------------------+");
            Console.WriteLine("\n");
        }
        public void DisplayError()
        {
            throw new Exception("ТЕКСТ НА ГРЕШКАТА");
        }

    }
}
