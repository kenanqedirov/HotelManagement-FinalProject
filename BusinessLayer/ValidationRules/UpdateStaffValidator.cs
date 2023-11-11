using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class UpdateStaffValidator : AbstractValidator<Staff>
    {
        public UpdateStaffValidator()
        {
            RuleFor(a => a.StaffName).NotEmpty().WithMessage("This field is not empty");
            RuleFor(a => a.StaffSurname).NotEmpty().WithMessage("This field is not empty");
            RuleFor(a => a.StaffJob).NotEmpty().WithMessage("This field is not empty");
            RuleFor(a => a.StaffDescription).NotEmpty().WithMessage("This field is not empty");
        }
    }
}
