using ECommerce.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccessLayer.Configurations
{
    public class ShipperConfiguration : BaseConfiguration<Shipper>
    {
        public override void Configure(EntityTypeBuilder<Shipper> builder)
        {
            base.Configure(builder);
            builder.HasMany(x => x.Orders).WithOne(x => x.Shipper).HasForeignKey(x => x.ShipperId);
        }
    }
}
