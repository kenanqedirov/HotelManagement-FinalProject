using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HotelManagement.Controllers
{
    [AllowAnonymous]
    public class RoomPageController : Controller
    {
        private readonly IRoomService _roomManager;

        public RoomPageController(IRoomService roomManager)
        {
            _roomManager = roomManager;
        }

        public IActionResult Index()
        {
            var values = _roomManager.TGetList().Where(a=>a.RoomStatus == false).ToList();
            return View(values);
        }
    }
}
