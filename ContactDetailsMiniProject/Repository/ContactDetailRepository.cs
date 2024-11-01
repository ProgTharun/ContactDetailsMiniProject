using ContactDetailsMiniProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDetailsMiniProject.Controller
{
    public class ContactDetailRepository
        {
            public static List<ContactDetail> contactDetails = new List<ContactDetail>();

            public static void AddContactDetail(ContactDetail contactDetail)
            {
                contactDetails.Add(contactDetail);
            }

            public static void ModifyContactDetail(int contactDetailId, ContactDetail updatedDetail)
            {
                var detail = contactDetails.FirstOrDefault(cd => cd.ContactDetailId == contactDetailId);
                if (detail != null)
                {
                    detail.Type = updatedDetail.Type;
                    detail.NumberOrEmail = updatedDetail.NumberOrEmail;
                }
            }
        public static ContactDetail FindContactDetailById(int contactDetailId)
        {
            return contactDetails.FirstOrDefault(cd => cd.ContactDetailId == contactDetailId);
        }
        public static void DeleteContactDetail(int contactDetailId)
            {
                var detail = contactDetails.FirstOrDefault(cd => cd.ContactDetailId == contactDetailId);
                if (detail != null)
                {
                detail = null;
                }
            }

            public static List<ContactDetail> GetAllContactDetails()
            {
                return contactDetails;
            }

           
        }
    }

