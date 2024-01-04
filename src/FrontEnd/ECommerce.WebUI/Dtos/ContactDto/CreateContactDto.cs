using ECommerce.EntityLayer.Concrete;

namespace ECommerce.WebUI.Dtos.ContactDto
{
    public class CreateContactDto : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
