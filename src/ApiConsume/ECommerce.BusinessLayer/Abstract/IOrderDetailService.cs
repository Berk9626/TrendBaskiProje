using ECommerce.BusinessLayer.Repositories.Abstract;
using ECommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLayer.Abstract
{
    public interface IOrderDetailService : IGenericService<OrderDetail>
    {
        string TCreateOrderDetail(OrderDetail orderDetail);
        decimal GetTotalRevenueUntilToday();
        decimal GetMonthlyRevenue();
        decimal GetWeeklyRevenue();
        decimal GetDailyRevenue();
    }
}
