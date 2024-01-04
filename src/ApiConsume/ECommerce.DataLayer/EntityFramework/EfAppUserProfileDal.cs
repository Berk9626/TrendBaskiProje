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
    public class EfAppUserProfileDal : GenericRepository<AppUserProfile>, IAppUserProfileDal
    {
        public EfAppUserProfileDal(Context context) : base(context)
        {
        }
    }
}
