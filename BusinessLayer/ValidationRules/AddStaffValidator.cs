using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AddStaffValidator : AbstractValidator<Staff>
    {
        public AddStaffValidator()
        {
            RuleFor(a => a.StaffName).NotEmpty().WithMessage("This field is not empty");
            RuleFor(a => a.StaffSurname).NotEmpty().WithMessage("This field is not empty");
            RuleFor(a => a.StaffJob).NotEmpty().WithMessage("This field is not empty");
            RuleFor(a => a.StaffDescription).NotEmpty().WithMessage("This field is not empty");
            RuleFor(a => a.StaffImageFile).NotEmpty().WithMessage("This field is not empty");
        }
    }
}
