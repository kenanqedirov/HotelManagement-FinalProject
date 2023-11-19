using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.ViewModels
{
    public class AddReservationViewModel
    {
        public int RoomId { get; set; }
        public Room MyRoom { get; set; }
        [Required]
        public DateTime StartDay { get; set; }
        [Required]
        public DateTime EndDay { get; set; }

    }
}
