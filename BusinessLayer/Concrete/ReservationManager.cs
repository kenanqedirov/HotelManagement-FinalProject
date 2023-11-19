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
	public class ReservationManager : IReservationService
	{
		private readonly IReservationDAL _reservationDAL;

		public ReservationManager(IReservationDAL reservationDAL)
		{
			_reservationDAL = reservationDAL;
		}

		public void TAdd(Reservation t)
		{
			_reservationDAL.Insert(t);
		}

		public void TDelete(Reservation t)
		{
			_reservationDAL.Delete(t);
		}

		public Reservation TGetById(int id)
		{
			return _reservationDAL.GetById(id);
		}

		public List<Reservation> TGetList()
		{
			return _reservationDAL.GetList();
		}

        public List<Reservation> TGetReservationWithRoom()
        {
			return _reservationDAL.GetReservationWithRoom();
        }

        public void TUpdate(Reservation t)
		{
			_reservationDAL.Update(t);
		}
	}
}
