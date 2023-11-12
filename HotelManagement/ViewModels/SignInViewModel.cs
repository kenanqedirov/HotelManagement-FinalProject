using System.ComponentModel.DataAnnotations;

namespace HotelManagement.ViewModels
{
	public class SignInViewModel
	{
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
