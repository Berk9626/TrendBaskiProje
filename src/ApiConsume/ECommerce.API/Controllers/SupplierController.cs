using ECommerce.BusinessLayer.Abstract;
using ECommerce.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }
        //---------------------------------------------------------
        [HttpGet]
        public IActionResult SupplierList()
        {
            try
            {
                var values = _supplierService.GetAll();
                return Ok(values);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        //---------------------------------------------------------
        [HttpGet("{id}")]
        public IActionResult GetSupplier(int id)
        {
            try
            {
                var model = _supplierService.GetById(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        //---------------------------------------------------------
        [HttpPost]
        public IActionResult AddSupplier(Supplier supplier)
        {
            try
            {
                _supplierService.Add(supplier);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        //---------------------------------------------------------
        [HttpPut]
        public IActionResult UpdateSupplier(Supplier supplier)
        {
            try
            {
                _supplierService.Update(supplier);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        //---------------------------------------------------------
        [HttpDelete("DeleteSupplier/{id}")]
        public IActionResult DeleteSupplier(int id)
        {
            try
            {
                var values = _supplierService.GetById(id);
                _supplierService.Destroy(values);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        //---------------------------------------------------------
        [HttpDelete("DeletedStatusSupplier/{id}")]
        public IActionResult DeletedStatusSupplier(int id)
        {
            try
            {
                var values = _supplierService.GetById(id);
                _supplierService.Delete(values);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        //---------------------------------------------------------
        [HttpGet("GetActivesSupplier")]
        public IActionResult GetActivesBooking()
        {
            try
            {
                var values = _supplierService.GetActives();
                return Ok(values);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        //---------------------------------------------------------
        [HttpGet("GetActiveSupplier/{id}")]
        public IActionResult GetActiveSupplier(int id)
        {
            try
            {
                var values = _supplierService.GetById(id);
                _supplierService.GetActive(values);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        //---------------------------------------------------------

    }
}
