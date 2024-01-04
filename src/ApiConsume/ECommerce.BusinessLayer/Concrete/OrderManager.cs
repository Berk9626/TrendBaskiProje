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

namespace ECommerce.BusinessLayer.Concrete
{
    public class OrderManager : BaseManager<Order>, IOrderService
    {
        private readonly IOrderDal _orderDal; 

        public OrderManager(IOrderDal orderDal): base(orderDal)
        {
            _orderDal = orderDal;
        }

        public string CreateOrder(Order order)
        {
            return _orderDal.CreateOrder(order);
        }

        public void GetChangeOrderStatusAsOnTheWay(int id)
        {
            _orderDal.GetChangeOrderStatusAsOnTheWay(id);
        }

        public void GetChangeOrderStatusAsStillWaiting(int id)
        {
            _orderDal.GetChangeOrderStatusAsStillWaiting(id);
        }

        public Order GetOrderForOnlyEmail(int id)
        {
            return _orderDal.GetOrderForOnlyEmail(id);
        }

        public void GetChangeOrderStatusAsCanceled(int id)
        {
            _orderDal.GetChangeOrderStatusAsCanceled(id);
        }

        public int GetOrderCount()
        {
            return _orderDal.GetOrderCount();
        }

        public List<Order> LastFourOrder()
        {
            return _orderDal.LastFourOrder();
        }
    }
}
