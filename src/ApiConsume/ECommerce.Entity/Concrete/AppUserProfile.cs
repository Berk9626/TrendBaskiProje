using ECommerce.EntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECommerce.EntityLayer.Concrete
{
    public class AppUserProfile : BaseEntity

    {
        public int AppUserProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set;}
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string PostalCode { get; set; }
        public string ImageFile { get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; }

        //Relational Properties
        [JsonIgnore]
        public virtual AppUser AppUser { get; set; }    



    }
    
}
