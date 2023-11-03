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
	public class StaffManager : IStaffService
	{
		private readonly IStaffDAL _staffDAL;

		public StaffManager(IStaffDAL staffDAL)
		{
			_staffDAL = staffDAL;
		}

		public void TAdd(Staff t)
		{
			_staffDAL.Insert(t);
		}

		public void TDelete(Staff t)
		{
			_staffDAL.Delete(t);
		}

		public Staff TGetById(int id)
		{
			return _staffDAL.GetById(id);
		}

		public List<Staff> TGetList()
		{
			return _staffDAL.GetList();
		}

		public void TUpdate(Staff t)
		{
			_staffDAL.Update(t);
		}
	}
}
