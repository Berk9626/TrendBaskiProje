using ECommerce.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccessLayer.Configurations
{
    public class SupplierConfiguration : BaseConfiguration<Supplier>
    {
        public override void Configure(EntityTypeBuilder<Supplier> builder)
        {
            base.Configure(builder);
            builder.HasMany(x => x.Products).WithOne(x => x.Supplier).HasForeignKey(x => x.SupplierId);
        }
    }
}
