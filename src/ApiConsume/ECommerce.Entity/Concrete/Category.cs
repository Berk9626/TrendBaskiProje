using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECommerce.EntityLayer.Concrete
{
    public class Category : BaseEntity

    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }    
        public string CategoryDescription { get; set; }
        public string CategoryImage { get; set; }


        //Relational Properties
        [JsonIgnore]
        public List<Product> Products { get; set; }
        [JsonIgnore]
        public List<Booking> Bookings { get; set; }

    }
}
