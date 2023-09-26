﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.ValidationDTOs.ContactValidationDTOs
{
    public class ContactValidation
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public decimal Salary { get; set; }
    }
}
