﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide a value for Name field"), MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]

        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Office Email")]
        //[RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required]
        public Dept? Department { get; set; }

        public string PhotoPath { get; set; }
    }
}
