using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    [AllowAnonymous]
    public class StaffPageController : Controller
    {
        private readonly IStaffService _staffManager;

        public StaffPageController(IStaffService staffManager)
        {
            _staffManager = staffManager;
        }

        public IActionResult ReadMoreForStaff(int id)
        {
            var staff = _staffManager.TGetById(id);
            return View(staff);
        }
    }
}
