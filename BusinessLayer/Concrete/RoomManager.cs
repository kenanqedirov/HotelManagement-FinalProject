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
	public class RoomManager : IRoomService
	{
		private readonly IRoomDAL _roomDAL;

		public RoomManager(IRoomDAL roomDAL)
		{
			_roomDAL = roomDAL;
		}

		public void TAdd(Room t)
		{
			_roomDAL.Insert(t);
		}

		public void TDelete(Room t)
		{
			_roomDAL.Delete(t);
		}

		public Room TGetById(int id)
		{
			return _roomDAL.GetById(id);	
		}

		public List<Room> TGetList()
		{
			return _roomDAL.GetList();
		}

		public void TUpdate(Room t)
		{
			_roomDAL.Update(t);
		}
	}
}
