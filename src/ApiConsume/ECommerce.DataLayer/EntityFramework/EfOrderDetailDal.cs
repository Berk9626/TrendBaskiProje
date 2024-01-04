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
    public class EfOrderDetailDal : GenericRepository<OrderDetail>, IOrderDetailDal
    {
        private readonly Context _context;
        public EfOrderDetailDal(Context context) : base(context)
        {
            _context = context;
        }

        public string CreateOrderDetail(OrderDetail orderDetail)
        {           
                _context.OrderDetails.Add(orderDetail);
                _context.SaveChanges();
                return "sipariş detay oluşturuldu!";           
        }
       

        //public decimal GetTotalRevenueUntilToday()
        //{
        //    DateTime today = DateTime.Today;

        //    var totalRevenue = _context.OrderDetails
        //        .Where(od => od.Order.OrderDate.HasValue && od.Order.OrderDate.Value.Date <= today)
        //        .Sum(od => od.UnitPrice * od.Quantity) ?? 0;

        //    return totalRevenue;
        //}

        public decimal GetTotalRevenueUntilToday()
        {
            DateTime today = DateTime.Today;

            var totalRevenue = _context.OrderDetails
                .Where(od => od.Order.OrderDate.HasValue && od.Order.OrderDate.Value.Date <= today)
                .GroupBy(od => od.OrderId)
                .Select(group => group.Sum(od => od.UnitPrice * od.Quantity))
                .Sum() ?? 0;

            return totalRevenue;
        }

        //public decimal GetMonthlyRevenue()
        //{
        //    DateTime today = DateTime.Today;
        //    DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
        //    DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

        //    var monthlyRevenue = _context.OrderDetails
        //        .Where(od => od.Order.OrderDate.HasValue && od.Order.OrderDate >= firstDayOfMonth && od.Order.OrderDate.Value.Date <= lastDayOfMonth)
        //        .Sum(od => od.UnitPrice * od.Quantity) ?? 0;

        //    return monthlyRevenue;
        //}
        public decimal GetMonthlyRevenue()
        {
            DateTime today = DateTime.Today;
            DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            var monthlyRevenue = _context.OrderDetails
                .Where(od => od.Order.OrderDate.HasValue && od.Order.OrderDate >= firstDayOfMonth && od.Order.OrderDate.Value.Date <= lastDayOfMonth)
                .GroupBy(od => od.OrderId)
                .Select(group => group.Sum(od => od.UnitPrice * od.Quantity))
                .Sum() ?? 0;

            return monthlyRevenue;
        }

        //public decimal GetWeeklyRevenue()
        //{
        //    DateTime today = DateTime.Today;
        //    DayOfWeek currentDayOfWeek = today.DayOfWeek;
        //    int daysUntilMonday = ((int)DayOfWeek.Monday - (int)currentDayOfWeek + 7) % 7;

        //    DateTime startOfWeek = today.AddDays(daysUntilMonday * -1);
        //    DateTime endOfWeek = startOfWeek.AddDays(6);

        //    var weeklyRevenue = _context.OrderDetails
        //        .Where(od => od.Order.OrderDate.HasValue && od.Order.OrderDate >= startOfWeek && od.Order.OrderDate.Value.Date <= endOfWeek)
        //        .Sum(od => od.UnitPrice * od.Quantity) ?? 0;

        //    return weeklyRevenue;
        //}
        public decimal GetWeeklyRevenue()
        {
            DateTime today = DateTime.Today;
            DayOfWeek currentDayOfWeek = today.DayOfWeek;
            int daysUntilMonday = ((int)DayOfWeek.Monday - (int)currentDayOfWeek + 7) % 7;

            DateTime startOfWeek = today.AddDays(daysUntilMonday * -1);
            DateTime endOfWeek = startOfWeek.AddDays(6);

            var weeklyRevenue = _context.OrderDetails
                .Where(od => od.Order.OrderDate.HasValue && od.Order.OrderDate >= startOfWeek && od.Order.OrderDate.Value.Date <= endOfWeek)
                .GroupBy(od => od.OrderId)
                .Select(group => group.Sum(od => od.UnitPrice * od.Quantity))
                .Sum() ?? 0;

            return weeklyRevenue;
        }

        public decimal GetDailyRevenue()
        {
            DateTime today = DateTime.Today;

            var dailyRevenue = _context.OrderDetails
                .Where(od => od.Order.OrderDate.HasValue && od.Order.OrderDate.Value.Date == today)
                .GroupBy(od => od.OrderId)
                .Select(group => group.Sum(od => od.UnitPrice * od.Quantity))
                .Sum() ?? 0;

            return dailyRevenue;
        }

        //public decimal GetDailyRevenue()
        //{
        //    DateTime today = DateTime.Today;

        //    var dailyRevenue = _context.OrderDetails
        //        .Where(od => od.Order.OrderDate.HasValue && od.Order.OrderDate.Value.Date == today)
        //        .Sum(od => od.UnitPrice * od.Quantity) ?? 0;

        //    return dailyRevenue;
        //}
    }
}
