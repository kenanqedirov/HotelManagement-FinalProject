using EntityLayer.Concrete;
using HotelManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel signUpViewModel)
        {
            if (ModelState.IsValid)
            {
                if (signUpViewModel.Password == signUpViewModel.ConfirmPassword)
                {
                    AppUser user = new AppUser();
                    user.UserName = signUpViewModel.Username;
                    user.PhoneNumber = signUpViewModel.PhoneNumber;
                    user.Email = signUpViewModel.Mail;

                    var result = await _userManager.CreateAsync(user, signUpViewModel.Password);
                    
                    if (result.Succeeded)
                    {
                        var myuser = _userManager.Users.FirstOrDefault(a => a.UserName == signUpViewModel.Username);
                        await _userManager.AddToRoleAsync(myuser, "Member");
                        return RedirectToAction("SignIn", "Login");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
            }
            return View(signUpViewModel);
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel signInViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(signInViewModel.Username, signInViewModel.Password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "HomePage");
                }
            }
            return View(signInViewModel);
        }
        public IActionResult LogOut()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index","HomePage");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
