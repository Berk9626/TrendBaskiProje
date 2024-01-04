using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.EntityLayer.Concrete
{
    public  class Guest  : BaseEntity
    {
        public int GuestId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set;}

    }
}
