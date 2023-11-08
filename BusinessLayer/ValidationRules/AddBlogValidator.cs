using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AddBlogValidator : AbstractValidator<Blog>
    {
        public AddBlogValidator()
        {
            RuleFor(a => a.BlogCategory).NotEmpty().WithMessage("This field is not empty");
            RuleFor(a => a.BlogTitle).NotEmpty().WithMessage("This field is not empty");
            RuleFor(a => a.BlogDescription).NotEmpty().WithMessage("This field is not empty");
            RuleFor(a => a.BlogImageFile).NotEmpty().WithMessage("This field is not empty");

            RuleFor(a => a.BlogCategory).MinimumLength(4).WithMessage("This field must be minimum 4 character");
            RuleFor(a => a.BlogTitle).MinimumLength(4).WithMessage("This field must be minimum 4 character");
            RuleFor(a => a.BlogDescription).MinimumLength(50).WithMessage("This field must be minimum 50 character");
        }
    }
}
