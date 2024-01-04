using ECommerce.EntityLayer.Concrete;

namespace ECommerce.WebUI.Dtos.ReferanceDto
{
    public class CreateReferanceDto : BaseEntity
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
    }
}
