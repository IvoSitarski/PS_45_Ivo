using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;
using WelcomeExtended.Data;
using static WelcomeExtended.Others.Delegates;

namespace WelcomeExtended
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                UserData userData = new UserData();
                User studentUser1 = new User()
                {
                    Names="student1",
                    Password="12345",
                    Role=UserRolesEnum.STUDENT
                };

                User studentUser2 = new User()
                {
                    Names = "student2",
                    Password = "1234555555",
                    Role = UserRolesEnum.STUDENT
                };

                User studentUser3 = new User()
                {
                    Names = "student3",
                    Password = "12333333345",
                    Role = UserRolesEnum.STUDENT
                };

                userData.addUser(studentUser1);
                userData.addUser(studentUser2);
                userData.addUser(studentUser3);

                UserViewModel userView=new UserViewModel(studentUser1);
                UserView user = new UserView(userView);
                user.DisplayError();
                             
            }
            catch (Exception e)
            {
                var log = new ActionOnError(Log);
                log(e.Message);
                
            }
            finally
            {
                Console.WriteLine("Executed in any case!");
            }

        }
    }
}
