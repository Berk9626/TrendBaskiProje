using ECommerce.BusinessLayer.Abstract;
using ECommerce.BusinessLayer.Repositories.Concrete;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.Concrete;
using ECommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLayer.Concrete
{
    public class CategoryManager : BaseManager<Category>, ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal): base(categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Product> GetProductsWithCategoryId(int id)
        {
            return _categoryDal.GetProductsWithCategoryId(id);
        }
    }
}
