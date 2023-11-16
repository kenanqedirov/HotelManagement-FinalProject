using EntityLayer.Concrete;
using HotelManagement.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [AllowAnonymous]
    public class RolePageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        public RolePageController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = _roleManager.Roles.Where(a=>a.RoleStatus == true).ToList();
            return View(roles);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(AppRole role)
        {
            if (role is not null)
            {
                role.RoleStatus = true;
                await _roleManager.CreateAsync(role);
            }
            return RedirectToAction("Index", "RolePage", new { area = "Admin" });
        }

        [HttpGet]
        public IActionResult EditRole(int id)
        {
            var role = _roleManager.Roles.Where(a=>a.Id == id).FirstOrDefault();
            return View(role);
        }
        [HttpPost]
        public async Task<IActionResult> EditRole(AppRole role)
        {
            if (role is not null)
            {
                var roleDb = _roleManager.Roles.Where(a => a.Id == role.Id).FirstOrDefault();
                roleDb.Name = role.Name;
                await _roleManager.UpdateAsync(roleDb);
            }
            return RedirectToAction("Index", "RolePage", new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = _roleManager.Roles.Where(a=>a.Id == id).FirstOrDefault();
            role.RoleStatus = false;
            await _roleManager.UpdateAsync(role);
            return RedirectToAction("Index", "RolePage", new { area = "Admin" });
        }

    }

}
