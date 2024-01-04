using ECommerce.BusinessLayer.Abstract;
using ECommerce.EntityLayer.Concrete;
using ECommerce.WebUI.Dtos.ProductDto;
using ECommerce.WebUI.Dtos.ReferanceDto;
using ECommerce.WebUI.Models.ProductWithFile;
using ECommerce.WebUI.Models.ReferanceWithImage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferanceController : ControllerBase
    {
        private readonly IReferanceService _referanceService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ReferanceController(IReferanceService RefferanceService, IWebHostEnvironment webHostEnvironment)
        {
            _referanceService = RefferanceService;
            _webHostEnvironment = webHostEnvironment;
        }
        //---------------------------------------------------------
        [HttpGet]
        public IActionResult ReferanceList()
        {
            try
            {
                var values = _referanceService.GetAll();
                return Ok(values);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("GetAllWithImages")]
        public async Task<IActionResult> GetAllWithImages()
        {
            try
            {
                RefWithFile refWithFile = new RefWithFile(_webHostEnvironment);
                var referancelist = _referanceService.GetAll();

                if (referancelist != null && referancelist.Count > 0)
                {
                    referancelist.ForEach(item =>
                    {
                        item.Image = refWithFile.GetImagebyReferance(item.Image);
                    });

                    return Ok(referancelist);
                }
                else
                {
                    return Ok(new List<ResultReferanceDto>());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("{id}")]
        public IActionResult GetReferance(int id)
        {
            try
            {
                var model = _referanceService.GetById(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpPost]
        public IActionResult AddReferance(Referance referance)
        {
            try
            {
                _referanceService.Add(referance);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpPut]
        public IActionResult UpdateReferance(Referance referance)
        {
            try
            {
                _referanceService.Update(referance);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpDelete("DeleteReferance/{id}")]
        public IActionResult DeleteReferance(int id)
        {
            try
            {
                var values = _referanceService.GetById(id);
                _referanceService.Destroy(values);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpDelete("DeletedStatusReferance/{id}")]
        public IActionResult DeletedStatusReferance(int id)
        {
            try
            {
                var values = _referanceService.GetById(id);
                _referanceService.Delete(values);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("GetActivesReferance")]
        public IActionResult GetActivesBooking()
        {
            try
            {
                RefWithFile refWithFile = new RefWithFile(_webHostEnvironment);
                var referancelist = _referanceService.GetActives();

                if (referancelist != null && referancelist.Count > 0)
                {
                    referancelist.ForEach(item =>
                    {
                        item.Image = refWithFile.GetImagebyReferance(item.Image);
                    });

                    return Ok(referancelist);
                }
                else
                {
                    return Ok(new List<ResultReferanceDto>());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("GetActiveReferance/{id}")]
        public IActionResult GetActiveReferance(int id)
        {
            try
            {
                var values = _referanceService.GetById(id);
                _referanceService.GetActive(values);
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
