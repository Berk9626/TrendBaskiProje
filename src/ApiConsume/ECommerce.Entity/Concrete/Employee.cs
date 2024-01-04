using ECommerce.EntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECommerce.EntityLayer.Concrete
{
    public class Employee : BaseEntity
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string ImageFile { get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string SocialMedia1 { get; set; }
        public string SocialMedia2 { get; set; }
        public string SocialMedia3 { get; set; }



        //Relational Properties
        [JsonIgnore]
        public virtual List<Order> Orders { get; set; }
    }
}
