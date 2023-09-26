using AutoMapper;
using BLL.DTOs.ContacInfoDTOs;
using DAL.Entities;

namespace BLL.Configs.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        private void ContactsMapper()
        {
            CreateMap<ContactInfo, ContactResponse>();
            CreateMap<UpdateContactRequest, ContactInfo>();
            CreateMap<CreateContactRequest, ContactInfo>();
        }

        public AutoMapperProfile()
        {
            ContactsMapper();
        }
    }
}
