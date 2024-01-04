using ECommerce.EntityLayer.Concrete;
using ECommerce.EntityLayer.Enums;
using System.Text.Json.Serialization;

namespace ECommerce.WebUI.Dtos.AppUserDto
{
    public class ResultAppUserListDto
    {        
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
