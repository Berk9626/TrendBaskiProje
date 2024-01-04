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
    public class ContactManager : BaseManager<Contact>, IContactService
    {
        IContactDal _contactDal;
        public ContactManager(IContactDal ContactDal): base(ContactDal)
        {
            _contactDal = ContactDal;
        }

        public int GetContactCount()
        {
            return _contactDal.GetContactCount();
        }

        public Contact TGetById(int id)
        {
            return _contactDal.GetById(id);
            
        }
    }
}
