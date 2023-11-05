using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Container
{
	public static class Extensions
	{
		public static void ContainerDependencies(this IServiceCollection services)
		{
			services.AddScoped<IBlogService,BlogManager>();
			services.AddScoped<IContactFormService, ContactFormManager>();
			services.AddScoped<IHotelAboutService, HotelAboutManager>();
			services.AddScoped<IReservationService, ReservationManager>();
			services.AddScoped<IRoomService, RoomManager>();
			services.AddScoped<IStaffService, StaffManager>();

			services.AddScoped<IBlogDAL,EFBlogDAL>();
			services.AddScoped<IContactFormDAL,EFContactFormDAL>();
			services.AddScoped<IHotelAboutDAL, EFHotelAboutDAL>();
			services.AddScoped<IReservationDAL,EFReservationDAL>();
			services.AddScoped<IRoomDAL,EFRoomDAL>();
			services.AddScoped<IStaffDAL,EFStaffDAL>();
		}
	}
}
