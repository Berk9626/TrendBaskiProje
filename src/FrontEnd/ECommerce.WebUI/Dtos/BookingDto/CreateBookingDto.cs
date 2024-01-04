using ECommerce.EntityLayer.Concrete;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECommerce.WebUI.Dtos.BookingDto
{
    public class CreateBookingDto : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public IFormFile? ImageFile { get; set; }
        public string? Phone { get; set; }
        public string? SpecialRequest { get; set; }
        public int CategoryId { get; set; }

        [JsonIgnore]
        public virtual Category Category { get; set; }
    }
}
