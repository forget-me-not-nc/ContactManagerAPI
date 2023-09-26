using BLL.DTOs.ValidationDTOs.ContactValidationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.ValidatorService.ContactInfoValidator
{
    public interface IContactInfoValidator: IValidator<ContactValidation>
    {
        public void PhoneValidation(string phone);
        public void DateOfBirthValidation(DateTime dateOfBirth);
        public void SalaryValidation(decimal salary);
    }
}
