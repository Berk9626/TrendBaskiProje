﻿using ECommerce.DataAccessLayer.Repositories.Abstract;
using ECommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccessLayer.Abstract
{
    public interface IAppUserDal : IGenericDal<AppUser>
    {
        Task<bool> AddUser(AppUser item);       
    }



}
