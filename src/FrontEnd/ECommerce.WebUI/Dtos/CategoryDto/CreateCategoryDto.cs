using ECommerce.EntityLayer.Concrete;
using ECommerce.EntityLayer.Enums;
using System.Text.Json.Serialization;

namespace ECommerce.WebUI.Dtos.CategoryDto
{
    public class CreateCategoryDto: BaseEntity
    {

        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public IFormFile CategoryImage { get; set; }


        //Relational Properties
        [JsonIgnore]
        public List<Product> Products { get; set; }
        [JsonIgnore]
        public List<Booking> Bookings { get; set; }


    }
}
