using ECommerce.DataAccessLayer.Repositories.Abstract;
using ECommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccessLayer.Abstract
{
    public interface IOrderDal : IGenericDal<Order>
    {
        string CreateOrder(Order order);

        void GetChangeOrderStatusAsOnTheWay(int id);

        void GetChangeOrderStatusAsStillWaiting(int id);

        void GetChangeOrderStatusAsCanceled(int id);

        Order GetOrderForOnlyEmail(int id);
        void Includex();

        int GetOrderCount();

        List<Order> LastFourOrder();





    }
}
