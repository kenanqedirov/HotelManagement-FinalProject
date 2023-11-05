using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    public class ContactPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
