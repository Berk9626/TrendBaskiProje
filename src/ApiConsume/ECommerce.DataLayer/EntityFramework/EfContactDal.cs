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
    public class EfContactDal : GenericRepository<Contact>, IContactDal
    {
        private readonly Context _context;
        public EfContactDal(Context context) : base(context)
        {
            _context = context;
        }

        public int GetContactCount()
        {
            
            var values = _context.Contacts.Count();
            return values;
        }

        public Contact TGetById(int id)
        {
            
            var gelenid= _context.Contacts.Find(id);
            _context.SaveChanges();
            return gelenid;
        }
    }
}
