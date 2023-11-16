
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.ViewModels
{
    public class ContactFormViewModel
    {
        [Required(ErrorMessage ="This field is not empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is not empty")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "This field is not empty")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "This field is not empty")]
        public string Message { get; set; }

    }
}
