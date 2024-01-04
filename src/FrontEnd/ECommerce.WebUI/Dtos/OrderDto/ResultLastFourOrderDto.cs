using ECommerce.EntityLayer.Concrete;
using System.Text.Json.Serialization;

namespace ECommerce.WebUI.Dtos.OrderDto
{
    public class ResultLastFourOrderDto : BaseEntity
    {
        public ResultLastFourOrderDto()
        {
            OrderDetails = new List<OrderDetail>();
        }

        public int OrderId { get; set; }
        public Guid OrderBasket { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public string? ShipAddress { get; set; }
        public string? ShipCity { get; set; }
        public string? ShipRegion { get; set; }
        public string? ShipPostalCode { get; set; }
        public string? ShipCountry { get; set; }

        public int? EmployeeId { get; set; }
        public int? ShipperId { get; set; }
        public int AppUserId { get; set; }

        //Relational Properties
        [JsonIgnore]
        public virtual AppUser AppUser { get; set; }
        [JsonIgnore]
        public virtual Employee Employee { get; set; }
        [JsonIgnore]
        public virtual Shipper Shipper { get; set; }
        [JsonIgnore]
        public virtual List<OrderDetail> OrderDetails { get; set; }

    }
}
