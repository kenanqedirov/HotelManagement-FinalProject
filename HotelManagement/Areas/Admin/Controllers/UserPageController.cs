using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using HotelManagement.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [AllowAnonymous]
    public class UserPageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public UserPageController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var userList = _userManager.Users.ToList();
            return View(userList);
        }
        [HttpGet]
        public IActionResult AddRoleToUser(int id)
        {
            var user = _userManager.Users.Where(a => a.Id == id).FirstOrDefault();
            var rolesList = _roleManager.Roles.ToList();
            AddRoleToUserViewModel model = new AddRoleToUserViewModel
            {
                MyUserId = id,
                MyUsername = user.UserName,
                MyRoleList = rolesList
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddRoleToUser(AddRoleToUserViewModel model)
        {
            var user = _userManager.Users.FirstOrDefault(a => a.Id == model.MyUserId);
            //  var role = _roleManager.Roles.FirstOrDefault(a=>a.Id == model.MyRoleId);
            await _userManager.AddToRoleAsync(user,model.MyRoleId);
            return RedirectToAction("Index", "UserPage", new { area = "Admin" });

        }
    }
}
