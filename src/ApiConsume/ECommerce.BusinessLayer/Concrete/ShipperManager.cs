using ECommerce.BusinessLayer.Abstract;
using ECommerce.BusinessLayer.Repositories.Concrete;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLayer.Concrete
{
    public class ShipperManager : BaseManager<Shipper>, IShipperService
    {
        private readonly IShipperDal _shipperDal;

        public ShipperManager(IShipperDal shipperDal) : base(shipperDal)
        {
            _shipperDal = shipperDal;
        }
       
    }
}
