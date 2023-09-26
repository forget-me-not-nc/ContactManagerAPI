using AutoMapper;
using BLL.DTOs.ContacInfoDTOs;
using BLL.DTOs.ImportDTOs;
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

        private void CustomMapper()
        {
            CreateMap<CSVImportDTO, CreateContactRequest>();
        }

        public AutoMapperProfile()
        {
            ContactsMapper();
            CustomMapper();
        }
    }
}
