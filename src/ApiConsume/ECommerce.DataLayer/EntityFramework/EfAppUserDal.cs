using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.Concrete;
using ECommerce.DataAccessLayer.Repositories.Concretes;
using ECommerce.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccessLayer.EntityFramework
{
    public class EfAppUserDal : GenericRepository<AppUser>, IAppUserDal
    {
        UserManager<AppUser> _userManager;

        public EfAppUserDal(Context context, UserManager<AppUser> userManager) : base(context)
        {
            _userManager = userManager;
        }

        public async Task<bool> AddUser(AppUser item)
        {
            IdentityResult result = await _userManager.CreateAsync(item, item.PasswordHash);

            if (result.Succeeded) return true;
            //List<IdentityError> errors = new List<IdentityError>();
            //foreach (IdentityError error in result.Errors)
            //{
            //    errors.Add(error);
            //}
            return false;
        }       
    }
}
