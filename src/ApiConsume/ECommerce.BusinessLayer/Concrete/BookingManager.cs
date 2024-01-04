using ECommerce.BusinessLayer.Abstract;
using ECommerce.BusinessLayer.Repositories.Concrete;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ECommerce.BusinessLayer.Concrete
{
    public class BookingManager : BaseManager<Booking>, IBookingService
    { 
        IBookingDal _bookingDal;
        public BookingManager(IBookingDal bookingDal): base(bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public int GetBookingCount()
        {
            return _bookingDal.GetBookingCount();
        }

        public Booking GetBookingForOnlyEmail(int id)
        {
           return _bookingDal.GetBookingForOnlyEmail(id);
        }

        public void GetChangeBookingStatusAsApproved(int id)
        {
           _bookingDal.GetChangeBookingStatusAsApproved(id);
        }

        public void GetChangeBookingStatusAsKeepWaiting(int id)
        {
            _bookingDal.GetChangeBookingStatusAsKeepWaiting(id);
        }

        public void GetChangeOrderStatusAsCanceled(int id)
        {
            _bookingDal.GetChangeBookingStatusAsCanceled(id);
        }
       
    }
}
