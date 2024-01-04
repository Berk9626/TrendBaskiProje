using ECommerce.EntityLayer.Concrete;
using ECommerce.EntityLayer.Enums;
using System.Text.Json.Serialization;

namespace ECommerce.WebUI.Dtos.EmployeeDto
{
    public class UpdateEmployeeDto : BaseEntity
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string ImageFile { get; set; }
        public IFormFile ImagePath { get; set; }
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
