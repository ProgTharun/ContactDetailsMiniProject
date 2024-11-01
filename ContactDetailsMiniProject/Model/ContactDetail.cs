using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDetailsMiniProject.Model
{
        public class ContactDetail
        {
            public int ContactDetailId { get; set; }
            public string Type { get; set; }
            public string NumberOrEmail { get; set; }

        public ContactDetail(int contactdetail,string type,string numberoremail) 
        {
            ContactDetailId = contactdetail;
            Type = type;
            NumberOrEmail = numberoremail;
        }
        public override string ToString()
        {
            return $"ContactdetailId:{ContactDetailId}\n" +
                $"Type{Type}\n"+
                $"NumberOrEmaill{NumberOrEmail}";
        }
    }
}

