using ECommerce.EntityLayer.Enums;
using ECommerce.EntityLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.EntityLayer.Concrete
{
    public class BaseEntity : IEntity
    {
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            Status = DataStatus.Aktif;
        }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }
    }
}
