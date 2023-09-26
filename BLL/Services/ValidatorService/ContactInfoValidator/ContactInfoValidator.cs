using BLL.DTOs.ValidationDTOs.ContactValidationDTOs;
using DAL.Repos.ContactInfoRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL.Services.ValidatorService.ContactInfoValidator
{
    public class ContactInfoValidator : IContactInfoValidator
    {
        private readonly IContactInfoRepo _contactInfoRepo;

        public ContactInfoValidator(IContactInfoRepo contactInfoRepo)
        {
            _contactInfoRepo = contactInfoRepo;
        }

        public void DateOfBirthValidation(DateTime dateOfBirth)
        {
            if(DateTime.Now.Year - dateOfBirth.Year > 90 && DateTime.Now.Year - dateOfBirth.Year <= 14)
                throw new Exception("Invalid Date of Birth!");
        }

        public void PhoneValidation(string phone)
        {
            string pattern = @"^\+380\s?\d{9}$";

            if (!Regex.IsMatch(phone, pattern))
                throw new Exception("Invalif phone number!");

            if (_contactInfoRepo.GetContactByPhone(phone) != null)
                throw new Exception("Contact with such Phone number alreasy exist!");
        }

        public void SalaryValidation(decimal salary)
        {
            if (salary < 0.0m)
                throw new Exception("Invalid salary!");
        }

        public bool IsValid(ContactValidation entity)
        {
            DateOfBirthValidation(entity.DateOfBirth);
            PhoneValidation(entity.Phone);
            SalaryValidation(entity.Salary);

            return true;
        }

 
    }
}
