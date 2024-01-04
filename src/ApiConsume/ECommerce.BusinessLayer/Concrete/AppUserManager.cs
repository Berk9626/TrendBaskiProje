using ECommerce.BusinessLayer.Abstract;
using ECommerce.BusinessLayer.Repositories.Concrete;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.EntityFramework;
using ECommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLayer.Concrete
{
    public class AppUserManager : BaseManager<AppUser>, IAppUserService
    {
        IAppUserDal _apRep;

        public AppUserManager(IAppUserDal apRep) : base(apRep)
        {
            _apRep = apRep;
        }

        public async Task<bool> CreateUserAsync(AppUser item)
        {
            //todo : BL yazılır

            return await _apRep.AddUser(item);
        }

        
    }
}
