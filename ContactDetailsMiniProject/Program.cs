using ContactDetailsMiniProject.Controller;
using ContactDetailsMiniProject.Model;
using ContactDetailsMiniProject.Presentation;

namespace ContactDetailsMiniProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*******Welcome To Contact App **********");
            Console.WriteLine();
            Console.WriteLine("Creating an Admin User ...");
            User adminUser = new User(userid: 1, fname: "Admin", lname: "User", isadmin: true, isactive: true);
            UserRepository.AddUser(adminUser); 
            Console.WriteLine("Admin user created with UserId: 1");
            Console.WriteLine();
            Console.WriteLine("Creating an Staff User...");
            User adminUser1 = new User(userid: 2, fname: "Admin", lname: "User", isadmin: false, isactive: true);
            UserRepository.AddUser(adminUser1);
            Console.WriteLine("Staff user created with UserId: 2");
            Console.WriteLine();
            Menu menu = new Menu();
            menu.ShowMainMenu();
        }
    }
}
