using ContactDetailsMiniProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDetailsMiniProject.Controller
{
    public class UserRepository
    {
        public static List<User> users = new List<User>();

        public  static void AddUser(User user)
        {
            users.Add(user);
        }

        public static void ModifyUser(int userId, User updatedUser)
        {
            var user = users.FirstOrDefault(u => u.UserId == userId);
            if (user != null)
            {
                user.Fname = updatedUser.Fname;
                user.Lname = updatedUser.Lname;
                user.IsAdmin = updatedUser.IsAdmin;
                user.IsActive = updatedUser.IsActive;
            }
        }
        public static User FindUserById(int userId)
        {
            return users.FirstOrDefault(u => u.UserId == userId);
        }
        public static void DeleteUser(int userId)
        {
            var user = users.FirstOrDefault(u => u.UserId == userId);
            if (user != null)
            {
                user.IsActive = false;
            }
        }

        public static List<User> GetAllUsers()
        {
            return users;
        }

      
        public static void Exit()
        {
            Environment.Exit(0);
        }
    }
}
