using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECommerce.EntityLayer.Concrete
{
    public class Shipper : BaseEntity
    {
        public int ShipperId { get; set; }
        public string ShipperName { get; set; }
        public string ShipperEmail { get; set;}
        public string ShipperPhone { get; set;}

        //Relational Properties
        [JsonIgnore]
        public virtual List<Order> Orders { get; set; }

    }
}
