using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using BusinessLogicLayer.validators;
using System.ComponentModel;

namespace BusinessLogicLayer.DTO
{
   
    [FluentValidation.Attributes.Validator(typeof(GroupValidator))]
    public class GroupDTO
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Please enter group_number.")]

        public int group_number { get; set; }

        public GroupDTO(int group_number)
        {
            this.group_number = group_number;
        }
        public GroupDTO()
        {
            
        }
    }
}
