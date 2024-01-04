using ECommerce.EntityLayer.Concrete;

namespace ECommerce.WebUI.Dtos.AboutDto
{
    public class CreateAboutDto : BaseEntity
    {
        
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public string Content { get; set; }
        public string EmployeeCount { get; set; }
        public string CustomerCount { get; set; }
        public string ProductCount { get; set; }

    }
}
