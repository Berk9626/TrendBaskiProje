using ECommerce.EntityLayer.Concrete;

namespace ECommerce.WebUI.Dtos.ContactDto
{
    public class InboxContactDto : BaseEntity
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
