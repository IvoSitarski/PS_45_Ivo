using Welcome.Model;
using Welcome.View;
using Welcome.ViewModel;

namespace Welcome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User();
            user1.Names = "Ivo";
            user1.Password = "12345";
            user1.Role =Others.UserRolesEnum.STUDENT;
            user1.FacultyNumber = "121221332";
            user1.Email = "ipetrov@tu-sofia.bg";

            User user2 = new User();
            user2.Names = "Petar";
            user2.Password = "12345";
            user2.Role = Others.UserRolesEnum.ADMIN;
            user2.FacultyNumber = "121221223";
            user2.Email = "pivanov@tu-sofia.bg"; 

            UserViewModel userViewModel1=new UserViewModel(user1);
            UserViewModel userViewModel2 = new UserViewModel(user2);

            UserView view1= new UserView(userViewModel1);
            UserView view2 = new UserView(userViewModel2);

            view1.Display();
            view2.Display();

            view1.DisplayDetailed();
            view2.DisplayDetailed();

            view1.DisplayTable();
            view2.DisplayTable();

          
        }
    }
}
