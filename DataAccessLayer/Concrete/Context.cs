using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
	public class Context : DbContext
	{
		//public Context(DbContextOptions<Context> options) : base(options)
		//{

		//}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=localhost\\SQL; database=HotelDB;User Id=sa;Password=kenan4258;integrated security = true;");
		}
		public DbSet<Blog> Blogs { get; set; }
        public DbSet<ContactForm> ContactForms { get; set; }
        public DbSet<HotelAbout> HotelAbouts { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Staff> Staffs { get; set; }
    }
}
