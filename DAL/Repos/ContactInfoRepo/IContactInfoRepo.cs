using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.ContactInfoRepo
{
    public interface IContactInfoRepo: IGenericRepo<ContactInfo>
    {
        Task<ContactInfo> GetContactByPhone(string phoneNumber);
    }
}
