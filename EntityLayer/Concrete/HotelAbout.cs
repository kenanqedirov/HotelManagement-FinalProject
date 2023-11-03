using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class HotelAbout
	{
		[Key]
        public int AboutId { get; set; }
        public string HotelPhone { get; set; }
        public string HotelAddress { get; set; }
    }
}
