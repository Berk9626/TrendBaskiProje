using ECommerce.EntityLayer.Concrete;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ECommerce.WebUI.Dtos.ProductDto
{
    public class ResultProductDto : BaseEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal UnitPrice { get; set; }
        public string UnitsInStock { get; set; }//
        public string ImageFile { get; set; }
        public string Title { get; set; }
        public string Color { get; set; }//
        public string Size { get; set; }//
        public int SupplierId { get; set; }//
        public int CategoryId { get; set; }//

        //Relational Properties
        [JsonIgnore]
        public virtual Category Category { get; set; }
        [JsonIgnore]
        public virtual Supplier Supplier { get; set; }
        [JsonIgnore]
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
