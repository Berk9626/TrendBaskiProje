using ECommerce.DataAccessLayer.Repositories.Abstract;
using ECommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ECommerce.DataAccessLayer.Abstract
{
    public interface IBookingDal: IGenericDal<Booking>
    {
        int GetBookingCount();
        void GetChangeBookingStatusAsApproved(int id);
        void GetChangeBookingStatusAsKeepWaiting(int id);
        void GetChangeBookingStatusAsCanceled(int id);
        Booking GetBookingForOnlyEmail(int id);
        int GetEmploeeCount();



    }
}
