using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.Concrete;
using ECommerce.DataAccessLayer.Repositories.Concretes;
using ECommerce.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccessLayer.EntityFramework
{
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        private readonly Context _context;      
        public EfOrderDal(Context context) : base(context)
        {
           
           
            _context = context;
            

        }        
        public string CreateOrder(Order order)
        {                         
                _context.Orders.Add(order);
                _context.SaveChanges();
                return "Siparişiniz Oluşturuldu!";          
        }
        public void GetChangeOrderStatusAsOnTheWay(int id)
        {           
            var selectedorder = _context.Orders.Find(id);
            selectedorder.Status = ECommerce.EntityLayer.Enums.DataStatus.Kargoda;
            selectedorder.ShippedDate = DateTime.Now;
            selectedorder.ModifiedDate = DateTime.Now;
            _context.SaveChanges();
        }
        public void GetChangeOrderStatusAsStillWaiting(int id)
        {           
            var selectedorder = _context.Orders.Find(id);
            selectedorder.Status = ECommerce.EntityLayer.Enums.DataStatus.Beklemede;
            selectedorder.ModifiedDate = DateTime.Now;
            _context.SaveChanges();          
        }
        public void GetChangeOrderStatusAsCanceled(int id)
        {
            var selectedorder = _context.Orders.Find(id);
            selectedorder.Status = ECommerce.EntityLayer.Enums.DataStatus.İptal;
            selectedorder.ModifiedDate = DateTime.Now;
            _context.SaveChanges();
        }
        public Order GetOrderForOnlyEmail(int id)
        {
            return _context.Orders
            .Include(o => o.AppUser)
            .FirstOrDefault(o => o.OrderId == id);
            //_context.Orders.Find(id);

        }
        public void Includex()
        {
            _context.Orders.Include(o => o.AppUser).ToList();
            _context.SaveChanges();

        }

        public int GetOrderCount()
        {          
            var values = _context.Orders.Count();
            return values;
        }

        public List<Order> LastFourOrder()
        {
            var values = _context.Orders.OrderByDescending(x => x.OrderId).Take(4).ToList();
            return values;
        }
    }
}
