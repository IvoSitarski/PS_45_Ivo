using DataLayer.Database;
using DataLayer.Model;
using Welcome.Model;
using Welcome.Others;

namespace DataLayer

    //Домашното
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DatabaseContext())
            {
                context.Database.EnsureCreated();

                while (true)
                {
                    Console.WriteLine("1. List all users");
                    Console.WriteLine("2. Add a new user");
                    Console.WriteLine("3. Delete a user");
                    Console.WriteLine("4. Exit");
                    Console.Write("Select an option: ");

                    int option;
                    if (!int.TryParse(Console.ReadLine(), out option))
                    {
                        Console.WriteLine("Please enter a valid number.");
                        continue;
                    }

                    switch (option)
                    {
                        case 1:
                            ListUsers(context);
                            break;
                        case 2:
                            AddUser(context);
                            break;
                        case 3:
                            DeleteUser(context);
                            break;
                        case 4:
                            context.Log("Exited the application.");
                            return;
                        default:
                            Console.WriteLine("Invalid option, try again.");
                            break;
                    }
                }
            }
        }

        static void ListUsers(DatabaseContext context)
        {
            var users = context.Users.ToList();
            foreach (var user in users)
            {
                Console.WriteLine($"Name: {user.Names}, Email: {user.Email}");
            }
            context.Log("Listed all users.");
        }

        static void AddUser(DatabaseContext context)
        {
            Console.Write("Enter user name: ");
            string name = Console.ReadLine();
            Console.Write("Enter email: ");
            string email = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            Console.Write("Enter faculty number: ");
            string facultyNumber = Console.ReadLine();
            Console.Write("Enter role (ADMIN, STUDENT, PROFESSOR): ");
            string role = Console.ReadLine();
            Console.Write("Enter account expiry (years from now): ");
            int yearsToAdd = int.Parse(Console.ReadLine() ?? "0");

            var encryptedPassword = context.EncryptDecrypt(password);

            var user = new DatabaseUser
            {
                Names = name,
                Email = email,
                Password = encryptedPassword,
                FacultyNumber = facultyNumber,
                Role = (UserRolesEnum)Enum.Parse(typeof(UserRolesEnum), role),
                Expires = DateTime.Now.AddYears(yearsToAdd),
                IsActive = true
            };

            context.Users.Add(user);
            context.SaveChanges();
            context.Log($"Added user: {name}");
        }


        static void DeleteUser(DatabaseContext context)
        {
            Console.Write("Enter user name to delete: ");
            string name = Console.ReadLine();

            var user = context.Users.FirstOrDefault(u => u.Names == name);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
                context.Log($"Deleted user: {name}");
            }
            else
            {
                Console.WriteLine("User not found!");
            }
        }
    }


    //Упражнението без домашното
    /*
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DatabaseContext())
            {
                context.Database.EnsureCreated();
                context.Add<DatabaseUser>(new DatabaseUser()
                {
                    Names = "user",
                    Password = context.EncryptDecrypt("1234"),
                    Expires = DateTime.Now,
                    Role = UserRolesEnum.STUDENT,
                    FacultyNumber="121221123",
                    Email = "email",
                    IsActive = true
                    
                });
                context.SaveChanges();
                var users = context.Users.ToList();

                Console.Write("Enter username: ");
                string enteredName = Console.ReadLine();
                Console.Write("Enter password: ");
                string enteredPassword = Console.ReadLine();

                //context.EncryptDecrypt(enteredPassword);

                bool isValidUser = users.Any(u => u.Names == enteredName && context.EncryptDecrypt(u.Password) == enteredPassword);


                if (isValidUser)
                {
                    Console.WriteLine("Valid User!");
                }
                else
                {
                    Console.WriteLine("Invalid user!");
                }
                Console.ReadKey();
            }

        }
    }
    */
}
