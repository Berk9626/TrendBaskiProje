using ECommerce.BusinessLayer.Abstract;
using ECommerce.BusinessLayer.Repositories.Concrete;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.Concrete;
using ECommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLayer.Concrete
{
    public class OrderDetailManager : BaseManager<OrderDetail>, IOrderDetailService
    {
        IOrderDetailDal _orderDetailDal;

        public OrderDetailManager(IOrderDetailDal orderDetailDal): base(orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }

        public decimal GetDailyRevenue()
        {
            return _orderDetailDal.GetDailyRevenue();
        }

        public decimal GetMonthlyRevenue()
        {
            return _orderDetailDal.GetMonthlyRevenue();
        }

        public decimal GetTotalRevenueUntilToday()
        {
            return _orderDetailDal.GetTotalRevenueUntilToday();
        }

        public decimal GetWeeklyRevenue()
        {
            return _orderDetailDal.GetWeeklyRevenue();
        }

        public string TCreateOrderDetail(OrderDetail orderDetail)
        {
            return _orderDetailDal.CreateOrderDetail(orderDetail);
        }
    }
}
