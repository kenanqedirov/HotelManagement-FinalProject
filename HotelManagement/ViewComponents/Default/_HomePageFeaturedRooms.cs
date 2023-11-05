using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using HotelManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HotelManagement.ViewComponents.Default
{
    public class _HomePageFeaturedRooms : ViewComponent
    {
        private readonly IRoomService _roomManager;

        public _HomePageFeaturedRooms(IRoomService roomManager)
        {
            _roomManager = roomManager;
        }

        public IViewComponentResult Invoke()
        {
            Room presidentalRoom = _roomManager.TGetList().Last(a => a.RoomType == "Presidental");
            var StandartRooms = _roomManager.TGetList().Where(a=>a.RoomType== "Standart").OrderByDescending(a=>a.RoomId).Take(2).ToList();
            HomePageViewModel model = new HomePageViewModel
            {
                PresidentalRoom = presidentalRoom,
                StandartRoom = StandartRooms
            };
            return View(model);
        }
    }
}
