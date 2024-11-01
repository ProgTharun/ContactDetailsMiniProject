using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDetailsMiniProject.Model
{
    public class User
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public bool IsAdmin { get; set; }
        public int UserId { get; set; }
        public bool IsActive { get; set; }
        public User(int userid,string fname,string lname,bool isadmin,bool isactive) 
        {
            UserId = userid;
            Fname = fname;
            Lname = lname;
            IsAdmin = isadmin;
            IsActive = isactive;
        }
        public override string ToString()
        {
            return $"User Id:{UserId}/n" +
                $"Fname:{Fname}/n" +
                $"Lname:{Lname}/n"+
                $"IsAdmin:{IsAdmin}\n"+
                $"IsActive:{IsActive}\n";

                
        }
    }
}
