using ECommerce.BusinessLayer.Repositories.Abstract;
using ECommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLayer.Abstract
{
    public interface IAppUserService : IGenericService<AppUser>
    {
        Task<bool> CreateUserAsync(AppUser item);

    }
}
