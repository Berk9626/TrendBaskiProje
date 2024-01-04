using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.Concrete;
using ECommerce.DataAccessLayer.Repositories.Concretes;
using ECommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccessLayer.EntityFramework
{
    public class EfEmployeeDal : GenericRepository<Employee>, IEmployeeDal
    {
        private readonly Context _context;
        public EfEmployeeDal(Context context) : base(context)
        {
            _context = context;
        }

        public int GetEmploeeCount()
        {
            
            var values = _context.Employees.Count();
            return values;
        }

        public List<Employee> LastFourEmployee()
        {
            
            var values = _context.Employees.OrderByDescending(x => x.EmployeeId).Take(4).ToList();
            return values;
        }
    }
}
