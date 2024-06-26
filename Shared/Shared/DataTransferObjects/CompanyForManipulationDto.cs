﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record CompanyForManipulationDto
    {
        [Required(ErrorMessage = "The company name is a required field.")]
        [MaxLength(30, ErrorMessage = "Company name cannot be more than 30 characters.")]
        public string? Name { get; init; }

        [Required(ErrorMessage = "The address is a required field.")]
        [MaxLength(50, ErrorMessage = "Address cannot be more than 50 characters.")]
        public string? Address { get; init; }

        [Required(ErrorMessage = "The country is a required field")]
        [MaxLength(20, ErrorMessage = "The country name cannot be mre than 20 characters.")]
        public string? Country { get; init; }

        public IEnumerable<EmployeeForCreationDto>? Employees { get; init; }
    }
}
