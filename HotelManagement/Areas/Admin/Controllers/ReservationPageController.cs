using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HotelManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class ReservationPageController : Controller
    {
        private readonly IReservationService _reservationManager;
        private readonly IRoomService _roomManager;

        public ReservationPageController(IReservationService reservationManager, IRoomService roomManager)
        {
            _reservationManager = reservationManager;
            _roomManager = roomManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var reservations = _reservationManager.TGetReservationWithRoom().OrderByDescending(a => a.ReservationStartDay).ToList();
            return View(reservations);
        }

        public IActionResult DeleteReservation(int id)
        {
            var reservation = _reservationManager.TGetById(id);
            var room = _roomManager.TGetById(reservation.RoomId);
            room.isReserved = false;
            _roomManager.TUpdate(room);
            _reservationManager.TDelete(reservation);


            return RedirectToAction("Index", "ReservationPage", new { area = "Admin" });
        }
    }
}
