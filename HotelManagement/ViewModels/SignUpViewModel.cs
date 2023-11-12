using System.ComponentModel.DataAnnotations;

namespace HotelManagement.ViewModels
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage ="This field is not empty")]
        public string Username { get; set; }
		[Required(ErrorMessage = "This field is not empty")]
		public string PhoneNumber { get; set; }
		[Required(ErrorMessage = "This field is not empty")]
		public string Mail { get; set; }
		[Required(ErrorMessage = "This field is not empty")]
		public string Password { get; set; }
		[Required(ErrorMessage = "This field is not empty")]
		public string ConfirmPassword { get; set; }
    }
}
