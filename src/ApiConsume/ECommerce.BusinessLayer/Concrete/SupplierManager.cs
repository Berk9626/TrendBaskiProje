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
    public class SupplierManager : BaseManager<Supplier>, ISupplierService

    {
        private readonly ISupplierDal _supplierDal;

        public SupplierManager(ISupplierDal supplierDal): base(supplierDal)
        {
            _supplierDal = supplierDal;
        }
        
    }
}
