using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<IActionResult> AddStaff(Staff staff)
        {
            AddStaffValidator validationRules = new AddStaffValidator();
            ValidationResult result = validationRules.Validate(staff);
            if (result.IsValid)
            {
                var resource = Directory.GetCurrentDirectory();
                var extensions = Path.GetExtension(staff.StaffImageFile.FileName);
                var imageName = Guid.NewGuid() + extensions;
                var saveLocation = resource + "/wwwroot/images/staff_images/" + imageName;
                using var stream = new FileStream(saveLocation, FileMode.Create);
                await staff.StaffImageFile.CopyToAsync(stream);

                staff.StaffImage = imageName;
                staff.StaffStatus = true;
                _staffManager.TAdd(staff);
                return RedirectToAction("Index", "StaffPage", new { area = "Admin" });
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(staff);
        }
        [HttpGet]
        public IActionResult DeleteStaff(int id)
        {
            var staff = _staffManager.TGetById(id);
            staff.StaffStatus = false;
            if (System.IO.File.Exists(System.IO.Directory.GetCurrentDirectory() + "/wwwroot/images/staff_images/" + staff.StaffImage))
            {
                System.IO.File.Delete(System.IO.Directory.GetCurrentDirectory() + "/wwwroot/images/staff_images/" + staff.StaffImage);
            }
            _staffManager.TUpdate(staff);
            return RedirectToAction("Index", "StaffPage", new { area = "Admin" });
        }

        [HttpGet]
        public IActionResult UpdateStaff(int id)
        {
            var staff = _staffManager.TGetById(id);
            return View(staff);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStaff(Staff staff)
        {
            UpdateStaffValidator validationRules = new UpdateStaffValidator();
            ValidationResult result = validationRules.Validate(staff);
            if (result.IsValid)
            {
                var staffDb = _staffManager.TGetById(staff.StaffId);
                if (staff.StaffImageFile is null)
                {
                    staffDb.StaffImage = staff.StaffImage;
                }
                else
                {
                    if (System.IO.File.Exists(System.IO.Directory.GetCurrentDirectory() + "/wwwroot/images/staff_images/" + staff.StaffImage))
                    {
                        System.IO.File.Delete(System.IO.Directory.GetCurrentDirectory() + "/wwwroot/images/staff_images/" + staff.StaffImage);
                    }
                    var resource = Directory.GetCurrentDirectory();
                    var extensions = Path.GetExtension(staff.StaffImageFile.FileName);
                    var imageName = Guid.NewGuid() + extensions;
                    var saveLocation = resource + "/wwwroot/images/staff_images/" + imageName;
                    using var stream = new FileStream(saveLocation, FileMode.Create);
                    await staff.StaffImageFile.CopyToAsync(stream);

                    staffDb.StaffImage = imageName;
                }
                staffDb.StaffName = staff.StaffName;
                staffDb.StaffSurname = staff.StaffSurname;
                staffDb.StaffJob = staff.StaffJob;
                staffDb.StaffDescription = staff.StaffDescription;

                _staffManager.TUpdate(staffDb);
                return RedirectToAction("Index", "StaffPage", new { area = "Admin" });
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(staff);
        }

        [HttpGet]
        public IActionResult DetailStaff(int id)
        {
            var staff = _staffManager.TGetById(id);
            return View(staff);
        }
    }
}
