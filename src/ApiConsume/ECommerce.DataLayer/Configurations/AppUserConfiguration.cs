using ECommerce.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccessLayer.Configurations
{
    public class AppUserConfiguration : BaseConfiguration<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            base.Configure(builder);
            builder.Ignore(x => x.AppUserId);
            builder.HasOne(x => x.AppUserProfile).WithOne(x => x.AppUser).HasForeignKey<AppUserProfile>(x => x.AppUserProfileId);
            builder.HasMany(x => x.Orders).WithOne(x => x.AppUser).HasForeignKey(x => x.AppUserId);
        }

    }
}
