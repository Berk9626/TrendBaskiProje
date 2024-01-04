using ECommerce.BusinessLayer.Abstract;
using ECommerce.BusinessLayer.Repositories.Concrete;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.EntityLayer.Concrete;
using ECommerce.EntityLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLayer.Concrete
{
    public class SubscribeManager : BaseManager<Subscribe>, ISubscribeService
    {
        private readonly ISubscribeDal _subscribeDal;
        public SubscribeManager(ISubscribeDal subscribeDal) : base(subscribeDal)
        {
            _subscribeDal = subscribeDal;
        }
      
    }
}
