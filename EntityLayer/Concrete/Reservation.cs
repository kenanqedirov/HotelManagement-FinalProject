using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Reservation
	{
        [Key] 
        public int ReservationId { get; set; }
        public DateTime ReservationStartDay { get; set; }
        public DateTime ReservationEndDay { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }

        // UserId

    }
}
