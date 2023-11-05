using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    public class BookNowPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
