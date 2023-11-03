using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class HotelAboutManager : IHotelAboutService
	{
		private readonly IHotelAboutDAL _hotelAboutDAL;

		public HotelAboutManager(IHotelAboutDAL hotelAboutDAL)
		{
			_hotelAboutDAL = hotelAboutDAL;
		}

		public void TAdd(HotelAbout t)
		{
			_hotelAboutDAL.Insert(t);
		}

		public void TDelete(HotelAbout t)
		{
			_hotelAboutDAL.Delete(t);
		}

		public HotelAbout TGetById(int id)
		{
			return _hotelAboutDAL.GetById(id);
		}

		public List<HotelAbout> TGetList()
		{
			return _hotelAboutDAL.GetList();
		}

		public void TUpdate(HotelAbout t)
		{
			_hotelAboutDAL.Update(t);
		}
	}
}
