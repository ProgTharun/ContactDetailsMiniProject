using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDetailsMiniProject.Model
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public bool IsActive { get; set; }
        public List<ContactDetail> ContactDetails { get; set; }
        public Contact(int contactid,string fname,string lname,bool isactive) 
        {
            ContactId = contactid;
            Fname = fname;
            Lname = lname;
            IsActive = isactive;

        }
        public override string ToString()
        {
            return $"Contact Id:{ContactId}\n"+
                $"Fname:{Fname}\n"+
                $"Lname:{Lname}\n"+
                $"IsActive:{IsActive}";
        }

    }

}
