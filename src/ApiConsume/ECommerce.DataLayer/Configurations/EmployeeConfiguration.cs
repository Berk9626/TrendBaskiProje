using ECommerce.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccessLayer.Configurations
{
    public class EmployeeConfiguration : BaseConfiguration<Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            base.Configure(builder);
            builder.HasMany(x => x.Orders).WithOne(x => x.Employee).HasForeignKey(x => x.EmployeeId);

        }
    }
}
