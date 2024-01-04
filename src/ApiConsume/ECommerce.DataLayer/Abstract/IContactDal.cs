using ECommerce.DataAccessLayer.Repositories.Abstract;
using ECommerce.EntityLayer.Concrete;
using ECommerce.EntityLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccessLayer.Abstract
{
    public interface IContactDal : IGenericDal<Contact>
    {
        Contact TGetById(int id);
        int GetContactCount();
    }
}
