using ECommerce.BusinessLayer.Abstract;
using ECommerce.EntityLayer.Concrete;
using ECommerce.WebUI.Dtos.ProductDto;
using ECommerce.WebUI.Models.EmployeWithImage;
using ECommerce.WebUI.Models.ProductWithFile;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {     
        private readonly IEmployeeService _employeeService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public EmployeeController(IEmployeeService employeeService, IWebHostEnvironment webHostEnvironment)
        {
            _employeeService = employeeService;
            _webHostEnvironment = webHostEnvironment;
        }
        //---------------------------------------------------------
        [HttpGet]
        public IActionResult EmployeeList()
        {
            try
            {
                var values = _employeeService.GetAll();
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
                EmpWithFile empWithFile = new EmpWithFile(_webHostEnvironment);
                var employeetlist = _employeeService.GetAll();

                if (employeetlist != null && employeetlist.Count > 0)
                {
                    employeetlist.ForEach(item =>
                    {
                        item.ImageFile = empWithFile.GetImagebyEmployee(item.ImageFile);
                    });

                    return Ok(employeetlist);
                }
                else
                {
                    return Ok(new List<ResultProductDto>());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            try
            {
                var model = _employeeService.GetById(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            try
            {
                _employeeService.Add(employee);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpPut]
        public IActionResult UpdateEmployee(Employee employee)
        {
            try
            {
                _employeeService.Update(employee);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpDelete("DeleteEmployee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                var values = _employeeService.GetById(id);
                _employeeService.Destroy(values);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpDelete("DeletedStatusEmployee/{id}")]
        public IActionResult DeletedStatusEmployee(int id)
        {
            try
            {
                var values = _employeeService.GetById(id);
                _employeeService.Delete(values);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("GetActivesEmployee")]
        public IActionResult GetActivesEmployee()
        {
            try
            {
                EmpWithFile empWithFile = new EmpWithFile(_webHostEnvironment);
                var employeetlist = _employeeService.GetActives();

                if (employeetlist != null && employeetlist.Count > 0)
                {
                    employeetlist.ForEach(item =>
                    {
                        item.ImageFile = empWithFile.GetImagebyEmployee(item.ImageFile);
                    });

                    return Ok(employeetlist);
                }
                else
                {
                    return Ok(new List<ResultProductDto>());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("GetActiveEmployee/{id}")]
        public IActionResult GetActiveEmployee(int id)
        {
            try
            {
                var values = _employeeService.GetById(id);
                _employeeService.GetActive(values);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("GetLastFourEmployee")]
        public IActionResult GetLastFourEmployee()
        {
            try
            {
                EmpWithFile empWithFile = new EmpWithFile(_webHostEnvironment);
                var employeetlist = _employeeService.LastFourEmployee();

                if (employeetlist != null && employeetlist.Count > 0)
                {
                    employeetlist.ForEach(item =>
                    {
                        item.ImageFile = empWithFile.GetImagebyEmployee(item.ImageFile);
                    });

                    return Ok(employeetlist);
                }
                else
                {
                    return Ok(new List<ResultProductDto>());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
    }
}
