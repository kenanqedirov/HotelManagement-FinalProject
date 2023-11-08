using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string BlogImage { get; set; }
        public bool BlogStatus { get; set; }
        public bool isActiveBlog { get; set; }
        [NotMapped]
        public IFormFile BlogImageFile { get; set; }
    }
}
