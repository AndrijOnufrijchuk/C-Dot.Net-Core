using BusinessLogicLayer.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.validators
{
    public class GroupValidator : AbstractValidator<GroupDTO>
    {
        public GroupValidator()
        {
            
            RuleFor(x => x.group_number).NotNull().GreaterThanOrEqualTo(1).WithMessage("Greater than 0 ");
        }
    }
}
