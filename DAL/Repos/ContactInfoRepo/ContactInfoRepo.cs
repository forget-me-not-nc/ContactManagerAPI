using DAL.Entities;
using DAL.Settings;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAL.Repos.ContactInfoRepo
{
    public class ContactInfoRepo : GenericRepo<ContactInfo>, IContactInfoRepo
    {
        public ContactInfoRepo(CustomDbContext context) : base(context)
        {
        }

        public async Task<ContactInfo> GetContactByPhone(string phoneNumber)
        {
            return await _context.Infos
                .Where(e => e.Phone.Equals(phoneNumber))
                .FirstOrDefaultAsync();
        }
    }
}
