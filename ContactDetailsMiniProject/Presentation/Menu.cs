using ContactDetailsMiniProject.Controller;
using ContactDetailsMiniProject.Model;
using System;

namespace ContactDetailsMiniProject.Presentation
{
    public class Menu
    {
        public void ShowMainMenu()
        {
            Console.WriteLine("Enter UserId: ");
            int userId =Convert.ToInt32(Console.ReadLine());

            var user = UserRepository.FindUserById(userId);
            if (user == null)
            {
                Console.WriteLine("User does not exist.");
                return;
            }

            if (!user.IsActive)
            {
                Console.WriteLine("User is Not active.");
                return;
            }

            if (user.IsAdmin)
            {
                ShowAdminMenu();
            }
            else
            {
                ShowStaffMenu();
            }
        }

        private void ShowAdminMenu()
        {
            while (true)
            {
                Console.WriteLine("Admin Menu:");
                Console.WriteLine("1. Add new User");
                Console.WriteLine("2. Modify existing User");
                Console.WriteLine("3. Delete User (soft)");
                Console.WriteLine("4. Display all Users");
                Console.WriteLine("5. Find User");
                Console.WriteLine("6. Logout");

                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddNewUser();
                        break;
                    case 2:
                        ModifyExistingUser();
                        break;
                    case 3:
                        DeleteUser();
                        break;
                    case 4:
                        DisplayAllUsers();
                        break;
                    case 5:
                        FindUser();
                        break;
                    case 6:
                        LogOut();
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        private void DisplayAllUsers()
        {
            var users = UserRepository.GetAllUsers();
            if (users != null)
            {
                foreach (var user in users)
                {
                    Console.WriteLine(user);
                }
            }
        }
        private void AddNewUser()
        {
            Console.WriteLine("Enter User Id:");
            int userid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter First Name: ");
            string fname = Console.ReadLine();
            Console.WriteLine("Enter Last Name: ");
            string lname = Console.ReadLine();
            Console.WriteLine("Is Admin (true/false): ");
            bool isAdmin =Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Is Active Or Not:");
            bool isActive = Convert.ToBoolean(Console.ReadLine());

            User user = new User(userid, fname, lname, isAdmin, isActive);
            UserRepository.AddUser(user);
            Console.WriteLine("User added successfully.");
        }

        private void ModifyExistingUser()
        {
            Console.WriteLine("Enter UserId to modify: ");
            int userId =Convert.ToInt32(Console.ReadLine());

            var existingUser = UserRepository.FindUserById(userId);
            Console.WriteLine("Enter new First Name: ");
            existingUser.Fname = Console.ReadLine();
            Console.WriteLine("Enter new Last Name: ");
            existingUser.Lname = Console.ReadLine();
            Console.WriteLine("Is Admin (true/false): ");
            existingUser.IsAdmin =Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Is Active (true/false): ");
            existingUser.IsActive = Convert.ToBoolean(Console.ReadLine());

           
            if (existingUser == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            UserRepository.ModifyUser(userId, existingUser);
            Console.WriteLine("User modified successfully.");
        }

        private void DeleteUser()
        {
            Console.WriteLine("Enter User Id to Delete:");
            int userId = Convert.ToInt32(Console.ReadLine());   
            UserRepository.DeleteUser(userId);
            Console.WriteLine("User deleted successfully.");
        }

        

        private void FindUser()
        {
            Console.WriteLine("Enter User Id:");
            int userId =Convert.ToInt32(Console.ReadLine());
            var user = UserRepository.FindUserById(userId);
            if (user != null)
            {
                Console.WriteLine(user);
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        public void LogOut()
        {
            UserRepository.Exit();
        }

        private void ShowStaffMenu()
        {
            while (true)
            {
                Console.WriteLine("Staff Menu:");
                Console.WriteLine("1. Work on Contacts");
                Console.WriteLine("2. Work on Contact Details");
                Console.WriteLine("3. Logout");

                int choice =Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        WorkOnContacts();
                        break;
                    case 2:
                        WorkOnContactDetails();
                        break;
                    case 3:
                        LogOut();
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void WorkOnContacts()
        {
            while (true)
            {
                Console.WriteLine("Contact Operations:");
                Console.WriteLine("1 Add new Contact");
                Console.WriteLine("2. Modify Contact");
                Console.WriteLine("3. Delete Contact (soft)");
                Console.WriteLine("4. Display all Contacts");
                Console.WriteLine("5. Find Contact");
                Console.WriteLine("6. Return to Main Menu");

                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddNewContact();
                        break;
                    case 2:
                        ModifyContact();
                        break;
                    case 3:
                        DeleteContact();
                        break;
                    case 4:
                        DisplayAllContacts();
                        break;
                    case 5:
                        FindContactById();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void AddNewContact()
        {
            Console.WriteLine("Enter Contact ID:");
            int contactId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Is Active (true/false): ");
            bool isActive =Convert.ToBoolean(Console.ReadLine());

            var contact = new Contact(contactId, firstName, lastName, isActive);
            ContactRepository.AddContact( contact);
            Console.WriteLine("Contact added successfully.");
        }

        private void ModifyContact()
        {
            Console.WriteLine("Enter Contact Id to modify: ");
            int contactId = Convert.ToInt32(Console.ReadLine());

            var existingContact = ContactRepository.FindContactById(contactId);
            if (existingContact == null)
            {
                Console.WriteLine("Contact not found.");
                return;
            }

            Console.WriteLine("Enter new First Name: ");
            existingContact.Fname = Console.ReadLine();
            Console.WriteLine("Enter new Last Name: ");
            existingContact.Lname = Console.ReadLine();
            Console.WriteLine("Is Active (true/false): ");
            existingContact.IsActive =Convert.ToBoolean(Console.ReadLine());

            ContactRepository.ModifyContact(contactId, existingContact);
            Console.WriteLine("Contact modified successfully.");
        }

        private void DeleteContact()
        {
            Console.WriteLine("Enter Contact Id to Delete:");
            int contactId =Convert.ToInt32(Console.ReadLine());
            ContactRepository.DeleteContact(contactId);
            Console.WriteLine("Contact deleted successfully.");
        }

        private void DisplayAllContacts()
        {
            var contacts = ContactRepository.GetAllContacts();
            if (contacts != null)
            {
                foreach (var contact in contacts)
                {
                    Console.WriteLine(contact);
                }
            }
            Console.WriteLine();
        }

        private void FindContactById()
        {
            Console.WriteLine("Enter Contact Id:");
            int contactId = int.Parse(Console.ReadLine());
            var contact = ContactRepository.FindContactById(contactId);
            if (contact != null)
            {
                Console.WriteLine(contact);
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }

        private void WorkOnContactDetails()
        {
            while (true)
            {
                Console.WriteLine("Contact Details Operations:");
                Console.WriteLine("1. Add new Contact Detail");
                Console.WriteLine("2. Modify Contact Detail");
                Console.WriteLine("3. Delete Contact Detail");
                Console.WriteLine("4. Display all Contact Details");
                Console.WriteLine("5. Find Contact Detail");
                Console.WriteLine("6. Return to Main Menu");

                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddNewContactDetail();
                        break;
                    case 2:
                        ModifyContactDetail();
                        break;
                    case 3:
                        DeleteContactDetail();
                        break;
                    case 4:
                        DisplayAllContactDetails();
                        break;
                    case 5:
                        FindContactDetailById();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void AddNewContactDetail()
        {
            Console.WriteLine("Enter Contact Detail ID:");
            int contactDetailId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Type (e.g., Phone, Email): ");
            string type = Console.ReadLine();
            Console.WriteLine("Enter Number or Email: ");
            string numberOrEmail = Console.ReadLine();

            var contactDetail = new ContactDetail(contactDetailId, type, numberOrEmail);
            ContactDetailRepository.AddContactDetail(contactDetail);
            Console.WriteLine("Contact detail added successfully.");
        }

        private void ModifyContactDetail()
        {
            Console.WriteLine("Enter Contact Detail ID to modify:");
            int contactDetailId =Convert.ToInt32(Console.ReadLine());

            var existingDetail = ContactDetailRepository.FindContactDetailById(contactDetailId);
            if (existingDetail != null)
            {
                Console.WriteLine("Enter new Type (e.g., Phone, Email): ");
                string newType = Console.ReadLine();
                Console.WriteLine("Enter new Number or Email: ");
                string newNumberOrEmail = Console.ReadLine();

                var updatedDetail = new ContactDetail(contactDetailId, newType, newNumberOrEmail);
                ContactDetailRepository.ModifyContactDetail(contactDetailId, updatedDetail);
                Console.WriteLine("Contact detail modified successfully.");
            }
            else
            {
                Console.WriteLine("Contact detail not found.");
            }
        }

        private void DeleteContactDetail()
        {
            Console.WriteLine("Enter Contact Detail ID to delete:");
            int contactDetailId = Convert.ToInt32(Console.ReadLine());

            ContactDetailRepository.DeleteContactDetail(contactDetailId);
            Console.WriteLine("Contact detail deleted successfully.");
        }

        private void DisplayAllContactDetails()
        {
            var contactDetails = ContactDetailRepository.GetAllContactDetails();
            if (contactDetails.Count > 0)
            {
                foreach (var detail in contactDetails)
                {
                    Console.WriteLine(detail);
                }
            }
            else
            {
                Console.WriteLine("No contact details found.");
            }
        }

        private void FindContactDetailById()
        {
            Console.WriteLine("Enter Contact Detail ID:");
            int contactDetailId = Convert.ToInt32(Console.ReadLine());
            var contactDetail = ContactDetailRepository.FindContactDetailById(contactDetailId);
            if (contactDetail != null)
            {
                Console.WriteLine(contactDetail);
            }
            else
            {
                Console.WriteLine("Contact detail not found.");
            }
        }
    }
}
