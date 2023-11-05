using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    public class AboutPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
