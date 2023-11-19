using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFReservationDAL : GenericRepository<Reservation>, IReservationDAL
    {
        List<Reservation> IReservationDAL.GetReservationWithRoom()
        {
            Context c = new Context();
            return c.Reservations.Include(r => r.Room).ToList();
        }
    }
}
