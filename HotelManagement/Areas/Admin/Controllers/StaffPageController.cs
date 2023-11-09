using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HotelManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class StaffPageController : Controller
    {
        private readonly IStaffService _staffManager;

        public StaffPageController(IStaffService staffManager)
        {
            _staffManager = staffManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var staffsList = _staffManager.TGetList().Where(a=>a.StaffStatus is true).ToList();
            return View(staffsList);
        }
        [HttpGet]
        public IActionResult AddStaff()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStaff(Staff staff)
        {
            return View();
        }
    }
}
