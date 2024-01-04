using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.EntityLayer.Concrete
{
    public class About : BaseEntity
    {
        public int AboutId { get; set; }
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public string Content { get; set; }
        public string EmployeeCount { get; set; }
        public string CustomerCount { get; set; }
        public string ProductCount { get; set; }

    }
}
