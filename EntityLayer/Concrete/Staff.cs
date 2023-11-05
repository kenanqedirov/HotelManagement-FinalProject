using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Staff
	{
		[Key]
        public int StaffId { get; set; }
		public string StaffName { get; set; }
		public string StaffSurname { get; set; }
		public string StaffImage { get; set; }
        public string StaffJob { get; set; }
        public string StaffDescription { get; set; }
        public bool StaffStatus { get; set; }
    }
}
