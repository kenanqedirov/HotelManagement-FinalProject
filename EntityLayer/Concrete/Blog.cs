using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Blog
	{
        [Key]
        public int BlogId { get; set; }
        public string BlogCategory { get; set; }
        public string BlogTitle { get; set; }
        public string BlogDescription { get; set; }
    }
}
