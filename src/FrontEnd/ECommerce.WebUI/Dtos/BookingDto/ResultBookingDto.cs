using ECommerce.EntityLayer.Concrete;
using System.Text.Json.Serialization;

namespace ECommerce.WebUI.Dtos.BookingDto
{
    public class ResultBookingDto : BaseEntity
    {
        public int BookingId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string ImageFile { get; set; }
        public string Phone { get; set; }
        public string SpecialRequest { get; set; }
        public int CategoryId { get; set; }

        [JsonIgnore]
        public virtual Category Category { get; set; }
    }
}
