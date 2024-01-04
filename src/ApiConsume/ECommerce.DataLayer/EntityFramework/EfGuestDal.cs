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
    public class EfGuestDal : GenericRepository<Guest>, IGuestDal
    {
        private readonly Context _context;
        public EfGuestDal(Context context) : base(context)
        {
            _context = context;
        }
    }
}
