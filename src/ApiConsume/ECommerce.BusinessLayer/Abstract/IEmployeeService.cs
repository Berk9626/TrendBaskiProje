using ECommerce.BusinessLayer.Repositories.Abstract;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLayer.Abstract
{
    public interface IEmployeeService: IGenericService<Employee>
    {
        int GetEmploeeCount();
        public List<Employee> LastFourEmployee();
    }
}
