using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECommerce.EntityLayer.Concrete
{
    public class Supplier : BaseEntity
    {
        public int SupplierId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set;}
        public string ContactTitle { get; set;}
        public string Address { get; set;}
        public string City { get; set;}
        public string Region { get; set;}
        public string PostalCode { get; set;}
        public string Country { get; set;}
        public string Phone { get; set;}

        //Relational Properties
        [JsonIgnore]
        public virtual List<Product> Products { get; set; }

    }
}
