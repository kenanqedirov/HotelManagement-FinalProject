using EntityLayer.Concrete;
using System.Collections.Generic;

namespace HotelManagement.ViewModels
{
    public class HomePageViewModel
    {
        public Room PresidentalRoom { get; set; }
        public List<Room> StandartRoom=new List<Room>();
    }
}
