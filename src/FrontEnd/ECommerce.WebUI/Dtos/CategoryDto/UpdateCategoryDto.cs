using ECommerce.EntityLayer.Concrete;
using System.Text.Json.Serialization;

namespace ECommerce.WebUI.Dtos.CategoryDto
{
    public class UpdateCategoryDto : BaseEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string CategoryImage { get; set; }

        public IFormFile ImagePath { get; set; }


        //Relational Properties
        [JsonIgnore]
        public List<Product> Products { get; set; }
        [JsonIgnore]
        public List<Booking> Bookings { get; set; }

    }
}
