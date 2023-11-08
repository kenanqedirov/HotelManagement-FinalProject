using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class RoomPageController : Controller
    {
        private readonly IRoomService _roomManager;
        private readonly IWebHostEnvironment _env;
        public RoomPageController(IRoomService roomManager, IWebHostEnvironment env)
        {
            _roomManager = roomManager;
            _env = env;
        }

        public IActionResult Index()
        {
            var roomList = _roomManager.TGetList().Where(a=>a.isRoomActive == true).ToList();
            return View(roomList);
        }
        [HttpGet]
        public IActionResult AddRoom()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRoom(Room room)
        {
            AddRoomValidator validationRules = new AddRoomValidator();
            ValidationResult result = validationRules.Validate(room);
            if (result.IsValid)
            {
                var resource = Directory.GetCurrentDirectory();
                var extensions = Path.GetExtension(room.RoomImageFile.FileName);
                var imageName = Guid.NewGuid() + extensions;
                var saveLocation = resource + "/wwwroot/images/room_images/" + imageName;
                using var stream = new FileStream(saveLocation,FileMode.Create);
                await room.RoomImageFile.CopyToAsync(stream);

                room.RoomImage = imageName;
                room.RoomStatus = false;
                room.isRoomActive = true;
                _roomManager.TAdd(room);
                return RedirectToAction("Index", "RoomPage", new {area="Admin"});
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(room);
        }

        [HttpGet]
        public IActionResult DeleteRoom(int id)
        {
            var room = _roomManager.TGetById(id);
            room.isRoomActive = false;
            if (System.IO.File.Exists(System.IO.Directory.GetCurrentDirectory() + "/wwwroot/images/room_images/" + room.RoomImage))
            {
                System.IO.File.Delete(System.IO.Directory.GetCurrentDirectory() + "/wwwroot/images/room_images/" + room.RoomImage);
            }
            _roomManager.TUpdate(room);
            return RedirectToAction("Index", "RoomPage", new { area = "Admin" });
        }
        [HttpGet]
        public IActionResult UpdateRoom(int id)
        {
            var room = _roomManager.TGetById(id);
            return View(room);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRoom(Room room)
        {
            UpdateRoomValidator validationRules = new UpdateRoomValidator();
            ValidationResult result = validationRules.Validate(room);
            if (result.IsValid)
            {
                var roomDb = _roomManager.TGetById(room.RoomId);
                if (room.RoomImageFile is null)
                {
                    roomDb.RoomImage = room.RoomImage;                  
                }
                else
                {
                    if (System.IO.File.Exists(System.IO.Directory.GetCurrentDirectory() + "/wwwroot/images/room_images/" + room.RoomImage))
                    {
                        System.IO.File.Delete(System.IO.Directory.GetCurrentDirectory() + "/wwwroot/images/room_images/" + room.RoomImage);
                    }
                    var resource = Directory.GetCurrentDirectory();
                    var extensions = Path.GetExtension(room.RoomImageFile.FileName);
                    var imageName = Guid.NewGuid() + extensions;
                    var saveLocation = resource + "/wwwroot/images/room_images/" + imageName;
                    using var stream = new FileStream(saveLocation, FileMode.Create);

                    await room.RoomImageFile.CopyToAsync(stream);

                    roomDb.RoomImage = imageName;
                }
                roomDb.RoomType = room.RoomType;
                roomDb.RoomArea = room.RoomArea;
                roomDb.RoomPrice = room.RoomPrice;
                roomDb.RoomAbout = room.RoomAbout;
                roomDb.RoomStatus = false;
                roomDb.RoomCount = room.RoomCount;
                roomDb.isRoomActive = true;

                _roomManager.TUpdate(roomDb);
                return RedirectToAction("Index", "RoomPage", new { area = "Admin" });
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(room);
        }
        [HttpGet]
        public IActionResult DetailRoom(int id)
        {
            var room = _roomManager.TGetById(id);
            return View(room);
        }
    }
}
