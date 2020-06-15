using BusinessLogicLayer.validators;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogicLayer.DTO
{

    [FluentValidation.Attributes.Validator(typeof(StudentValidator))]
    public class StudentDTO
    {
     
        public string name { get; set; }
        [Required]

        [Range(0, 1000)]
        public int GroupId { get; set; }
    
    }
    }
