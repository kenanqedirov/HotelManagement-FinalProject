using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HotelManagement.ViewComponents.Default
{
    public class _AboutPageOurStaffs : ViewComponent
    {
        private readonly IStaffService _staffManager;

        public _AboutPageOurStaffs(IStaffService staffManager)
        {
            _staffManager = staffManager;
        }

        public IViewComponentResult Invoke()
        {
            var values = _staffManager.TGetList().OrderByDescending(a => a.StaffId).Take(3).ToList();
            return View(values);
        }
    }
}
