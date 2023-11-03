using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Room
	{
        [Key]
        public int RoomId { get; set; }
        public string RoomType { get; set; }
        public int RoomArea { get; set; }
        public int RoomPrice { get; set; }
        public string RoomAbout { get; set; }
        public string RoomImage { get; set; }
        public bool RoomStatus { get; set; }
        public int RoomCount { get; set; }

    }
}
