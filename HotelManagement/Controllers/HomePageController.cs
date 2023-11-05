using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    public class HomePageController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
