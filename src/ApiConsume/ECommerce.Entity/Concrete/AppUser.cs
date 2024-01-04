

using ECommerce.EntityLayer.Enums;
using ECommerce.EntityLayer.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECommerce.EntityLayer.Concrete
{
    public class AppUser: IdentityUser<int>, IEntity
    {
        //public AppUser()
        //{
        //    CreatedDate = DateTime.Now;
        //    Status = DataStatus.Aktif;
        //}

        public int AppUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }

        //Relational Properties
        [JsonIgnore]
        public virtual AppUserProfile AppUserProfile { get; set; }
        [JsonIgnore]
        public virtual List<Order> Orders { get; set; }      

    }
}
