using ContactDetailsMiniProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDetailsMiniProject.Controller
{
    
    public class ContactRepository
    {
        public static  List<Contact> contacts = new List<Contact>();

        public static void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }

        public static void ModifyContact(int contactId, Contact updatedContact)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == contactId);
            if (contact != null)
            {
                contact.Fname = updatedContact.Fname;
                contact.Lname = updatedContact.Lname;
                contact.IsActive = updatedContact.IsActive;
                contact.ContactDetails = updatedContact.ContactDetails;
            }
        }
        public static Contact FindContactById(int ContactId)
        {
            return contacts.FirstOrDefault(c => c.ContactId == ContactId);
        }
        public static void DeleteContact(int contactId)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == contactId);
            if (contact != null)
            {
                contact.IsActive = false;
            }
        }
        public static List<Contact> GetAllContacts()
        {
            return contacts;
        }
      
    }
}
