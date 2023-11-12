using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    [AllowAnonymous]
    public class ContactPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
