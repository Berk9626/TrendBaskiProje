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
    public class EmployeeManager : BaseManager<Employee>, IEmployeeService
    {

        IEmployeeDal _employeeDal;
        public EmployeeManager(IEmployeeDal employeeDal): base(employeeDal)
        {
            _employeeDal = employeeDal;
        }

        public int GetEmploeeCount()
        {
           return _employeeDal.GetEmploeeCount();
        }

        public List<Employee> LastFourEmployee()
        {
            return _employeeDal.LastFourEmployee();
        }
    }
}
