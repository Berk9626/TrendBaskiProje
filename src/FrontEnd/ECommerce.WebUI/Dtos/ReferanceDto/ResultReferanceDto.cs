using ECommerce.EntityLayer.Concrete;

namespace ECommerce.WebUI.Dtos.ReferanceDto
{
    public class ResultReferanceDto : BaseEntity
    {
        public int ReferanceId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
