using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.Concrete;
using ECommerce.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.DataAccessLayer.Repositories.Concretes;
using System.Web.Mvc;

namespace ECommerce.DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        private readonly Context _context;
        public EfBookingDal(Context context) : base(context)
        {
            _context = context;

        }

        public int GetBookingCount()
        {
            
            var values = _context.Bookings.Count();
            return values;
        }

        public Booking GetBookingForOnlyEmail(int id)
        {
            
            return _context.Bookings.Find(id);
                   
        }

        public void GetChangeBookingStatusAsApproved(int id)
        {
            
            var selectedbooking = _context.Bookings.Find(id);
            selectedbooking.Status = ECommerce.EntityLayer.Enums.DataStatus.Onaylandı;
            _context.SaveChanges();
        }

        public void GetChangeBookingStatusAsKeepWaiting(int id)
        {
            
            var selectedbooking = _context.Bookings.Find(id);
            selectedbooking.Status = ECommerce.EntityLayer.Enums.DataStatus.Beklemede;
            _context.SaveChanges();
        }

        public void GetChangeBookingStatusAsCanceled(int id)
        {
            
            var selectedbooking = _context.Bookings.Find(id);
            selectedbooking.Status = ECommerce.EntityLayer.Enums.DataStatus.İptal;
            _context.SaveChanges();
        }

        public int GetEmploeeCount()
        {
            
            var values = _context.Bookings.Count();
            return values;
        }
    }
}
