using BLL.DTOs.ContacInfoDTOs;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.ContactInfoServices
{
    public interface IContactInfoService
    {
        Task<IEnumerable<ContactResponse>> GetAllAsync();
        Task<ContactResponse> GetAsync(int id);

        Task<ContactInfo> GetContactInfoByPhone(string phone);

        Task<ContactResponse> UpdateAsync(UpdateContactRequest entity);
        Task<ContactResponse> CreateAsync(CreateContactRequest entity);
        Task DeleteAsync(int id);
    }
}
