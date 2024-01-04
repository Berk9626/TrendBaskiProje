using ECommerce.BusinessLayer.Abstract;
using ECommerce.BusinessLayer.Repositories.Concrete;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.Repositories.Abstract;
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
    public class AboutManager : BaseManager<About>, IAboutService
    {
        private readonly IAboutDal _aboutDal;
        public AboutManager(IAboutDal aboutDal): base(aboutDal)
        {
            _aboutDal = aboutDal;
        }
       
    }
}
