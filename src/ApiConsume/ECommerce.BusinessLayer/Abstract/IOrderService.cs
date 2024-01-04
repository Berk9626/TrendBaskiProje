using ECommerce.BusinessLayer.Repositories.Abstract;
using ECommerce.EntityLayer.Concrete;
using ECommerce.EntityLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLayer.Abstract
{
    public interface IOrderService : IGenericService<Order>
    {
        string CreateOrder(Order order);
        void GetChangeOrderStatusAsOnTheWay(int id);
        void GetChangeOrderStatusAsStillWaiting(int id);
        void GetChangeOrderStatusAsCanceled(int id);
        Order GetOrderForOnlyEmail(int id);
        int GetOrderCount();

        public List<Order> LastFourOrder();
    }
}
