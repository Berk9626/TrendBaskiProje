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
    public class ProductManager : BaseManager<Product>, IProductService

    {
        private readonly IProductDal _productDal;
        public ProductManager(IProductDal productDal): base(productDal)
        {
            _productDal = productDal;
        }

        public int GetProductCount()
        {
            return _productDal.GetProductCount();
        }
    }
}
