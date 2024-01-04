using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.Concrete;
using ECommerce.DataAccessLayer.Repositories.Concretes;
using ECommerce.EntityLayer.Concrete;
using ECommerce.EntityLayer.Enums;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        private readonly Context _context;
        public EfCategoryDal(Context context) : base(context)
        {
            _context = context;
        }
        public List<Product> GetProductsWithCategoryId(int id)
        {
            
            var listedproducts = _context.Products.Where(x => x.CategoryId == id).ToList();
            return listedproducts;
        }

    }
}
