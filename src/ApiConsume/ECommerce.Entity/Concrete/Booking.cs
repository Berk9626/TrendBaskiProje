using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECommerce.EntityLayer.Concrete
{
    public class Booking : BaseEntity
    {
        public int BookingId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string  Email { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public  string ImageFile { get; set; }
        public  string Phone { get; set; }
        public string SpecialRequest { get; set; }
        public int CategoryId { get; set; }

        [JsonIgnore]
        public virtual Category Category { get; set; }


    }
}
