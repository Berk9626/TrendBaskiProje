using ECommerce.DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLayer.DependencyResolvers
{
    public static class DbContextServiceInjection
    {

        public static IServiceCollection AddDbContextService (this IServiceCollection services)
        {
            ServiceProvider provider = services.BuildServiceProvider ();
            IConfiguration configuration = provider.GetService<IConfiguration>();
            services.AddDbContextPool<Context>(options => options.UseSqlServer());
            return services;
        }



    }
}
