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
    public class AppUserProfileManager : BaseManager<AppUserProfile>, IAppUserProfileService
    {
        IAppUserProfileDal _appUserProfileDal;

        public AppUserProfileManager(IAppUserProfileDal appUserProfileDal): base(appUserProfileDal)
        {
            _appUserProfileDal = appUserProfileDal;
        }
       
    }
}
