using ECommerce.EntityLayer.Concrete;
using System.Text.Json.Serialization;

namespace ECommerce.WebUI.Dtos.ShipperDto
{
    public class ResultShipperDto : BaseEntity
    {
        public int ShipperId { get; set; }
        public string ShipperName { get; set; }
        public string ShipperEmail { get; set; }
        public string ShipperPhone { get; set; }

        //Relational Properties
        [JsonIgnore]
        public virtual List<Order> Orders { get; set; }
    }
}
