using ECommerce.BusinessLayer.Repositories.Abstract;
using ECommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ECommerce.BusinessLayer.Abstract
{
    public interface IBookingService : IGenericService<Booking>
    {
        int GetBookingCount();
        void GetChangeBookingStatusAsApproved(int id);

        void GetChangeBookingStatusAsKeepWaiting(int id);

        void GetChangeOrderStatusAsCanceled(int id);

        Booking GetBookingForOnlyEmail(int id);
    }
}
