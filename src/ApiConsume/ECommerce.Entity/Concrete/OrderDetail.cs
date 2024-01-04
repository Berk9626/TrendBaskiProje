using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECommerce.EntityLayer.Concrete
{
    public class OrderDetail : BaseEntity
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal? UnitPrice { get; set; }



        //Relational Properties
        [JsonIgnore]
        public virtual Product Product { get; set; }
        [JsonIgnore]
        public virtual Order Order { get; set; }



    }
}
