using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using HotelManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace HotelManagement.Controllers
{
    [Authorize(Roles = "Member,Admin")]
    [Route("[controller]/[action]/{id?}")]
    public class BookNowPageController : Controller
    {
        private readonly IReservationService _reservationManager;
        private readonly IRoomService _roomManager;

        public BookNowPageController(IReservationService reservationManager, IRoomService roomManager)
        {
            _reservationManager = reservationManager;
            _roomManager = roomManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var rooms = _roomManager.TGetList().Where(a => a.isReserved == false).ToList();
            return View(rooms);
        }
        [HttpGet]
        public IActionResult AddReservation(int id)
        {
            var room =_roomManager.TGetById(id);
            var viewModel = new AddReservationViewModel
            {
                MyRoom = room,
                RoomId = id
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult AddReservation(AddReservationViewModel model)
         {
            if (ModelState.IsValid)
            {
                Reservation reservation = new Reservation
                {
                    RoomId = model.RoomId,
                    ReservationStartDay = model.StartDay,
                    ReservationEndDay = model.EndDay
                };
                _reservationManager.TAdd(reservation);

                var room = _roomManager.TGetById(model.RoomId);
                room.isReserved = true;
                _roomManager.TUpdate(room);

                return RedirectToAction("Index", "BookNowPage");
            }
            return View(model);
        }
    }
}
