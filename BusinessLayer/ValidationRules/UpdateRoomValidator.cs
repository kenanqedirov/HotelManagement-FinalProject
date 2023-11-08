using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class UpdateRoomValidator : AbstractValidator<Room>
    {
        public UpdateRoomValidator()
        {
            RuleFor(a => a.RoomType).NotEmpty().WithMessage("This field is not empty");
            RuleFor(a => a.RoomArea).NotEmpty().WithMessage("This field is not empty");
            RuleFor(a => a.RoomPrice).NotEmpty().WithMessage("This field is not empty");
            RuleFor(a => a.RoomAbout).NotEmpty().WithMessage("This field is not empty");
            RuleFor(a => a.RoomCount).NotEmpty().WithMessage("This field is not empty");

            RuleFor(a => a.RoomArea).ExclusiveBetween<Room, int>(0, 1000).WithMessage("This field is between 0 - 1000");
            RuleFor(a => a.RoomPrice).ExclusiveBetween<Room, int>(0, 100000).WithMessage("This field is between 0 - 100000");
            RuleFor(a => a.RoomPrice).ExclusiveBetween<Room, int>(0, 1000).WithMessage("This field is between 0 - 1000");
            RuleFor(a => a.RoomAbout).MinimumLength(50).WithMessage("This field is minimum 50 character");
        }
      
    }
}
