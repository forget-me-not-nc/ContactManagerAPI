﻿using AutoMapper;
using BLL.DTOs.ContacInfoDTOs;
using BLL.Services.ValidatorService.ContactInfoValidator;
using DAL.Entities;
using DAL.Repos.ContactInfoRepo;
using BLL.DTOs.ValidationDTOs.ContactValidationDTOs;

namespace BLL.Services.ContactInfoServices
{
    public class ContactInfoService : IContactInfoService
    {
        private readonly IContactInfoRepo _contactInfoRepo;
        private readonly IContactInfoValidator _contactInfoValidator;
        private readonly IMapper _mapper;

        public ContactInfoService(
            IContactInfoValidator contactInfoValidator,
            IContactInfoRepo contactInfoRepo,
            IMapper mapper)
        {
            _contactInfoRepo = contactInfoRepo;
            _mapper = mapper;
            _contactInfoValidator = contactInfoValidator;
        }

        public async Task<ContactResponse> CreateAsync(CreateContactRequest entity)
        {
            await IsContactValid(new ContactValidation
            {
                DateOfBirth = entity.DateOfBirth,
                Phone = entity.Phone,
                Salary = entity.Salary,
            });

            var newContact = await _contactInfoRepo.CreateAsync(_mapper.Map<ContactInfo>(entity));

            await _contactInfoRepo.SaveChangesAsync();

            return _mapper.Map<ContactResponse>(newContact);
        }

        public async Task<IEnumerable<ContactResponse>> CreateRangeAsync(IEnumerable<CreateContactRequest> entities)
        {
            var createdTasks = new List<ContactResponse>();
            var exceptions = new List<Exception>();

            foreach (var entity in entities)
            {
                try
                {
                    var task = await CreateAsync(entity);
                    createdTasks.Add(task);
                }
                catch (Exception ex)
                { 
                    exceptions.Add(ex);
                };
            }

            if(exceptions.Count > 0)
            {
                throw new AggregateException($"Some exceptions occurred! Rows affected: {exceptions.Count}", exceptions);
            }

            return createdTasks;
        }

        public async Task DeleteAsync(int id)
        {
            await _contactInfoRepo.DeleteAsync(id);

            await _contactInfoRepo.SaveChangesAsync();
        }

        public async Task<IEnumerable<ContactResponse>> GetAllAsync()
        {
            return (await _contactInfoRepo.GetAllAsync())
               .Select(el => _mapper.Map<ContactResponse>(el));
        }

        public async Task<ContactResponse> GetAsync(int id)
        {
            var user = await _contactInfoRepo.GetByIdAsync(id);

            return _mapper.Map<ContactResponse>(user);
        }

        public async Task<ContactInfo> GetContactInfoByPhone(string phone)
        {
            return await _contactInfoRepo.GetContactByPhone(phone);
        }

        public async Task<bool> IsContactValid(ContactValidation contact)
        {
            _contactInfoValidator.IsValid(contact);

            if (contact.Id > 0)
            {
                var existingContact = await _contactInfoRepo.GetByIdAsync(contact.Id);

                if (existingContact != null)
                {
                    if (!existingContact.Phone.Equals(contact.Phone))
                    {
                        if (await GetContactInfoByPhone(contact.Phone) != null)
                        {
                            throw new Exception("Contact with such Phone number already exists!");
                        }
                    }

                   await _contactInfoRepo.Detache(existingContact);
                }
            }
            else
            {
                if (await GetContactInfoByPhone(contact.Phone) != null)
                {
                    throw new Exception("Contact with such Phone number already exists!");
                }
            }

            return await Task.FromResult(true);
        }

        public async Task<ContactResponse> UpdateAsync(UpdateContactRequest entity)
        {
            await IsContactValid(new ContactValidation
            {
                Id = entity.Id,
                DateOfBirth = entity.DateOfBirth,
                Phone = entity.Phone,
                Salary = entity.Salary,
            });

            var newContact = await _contactInfoRepo.UpdateAsync(_mapper.Map<ContactInfo>(entity));

            await _contactInfoRepo.SaveChangesAsync();

            return _mapper.Map<ContactResponse>(newContact);
        }
    }
}
