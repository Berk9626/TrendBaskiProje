using ECommerce.BusinessLayer.Abstract;
using ECommerce.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        //---------------------------------------------------------
        [HttpGet]
        public IActionResult ContactList()
        {
            try
            {
                var values = _contactService.GetAll();
                return Ok(values);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            try
            {
                var model = _contactService.GetById(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("GetSendingMessage/{id}")] //Added
        public IActionResult GetSendingMessage(int id)
        {
            try
            {
                var model = _contactService.GetById(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            try
            {
                _contactService.Add(contact);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpPut]
        public IActionResult UpdateContact(Contact contact)
        {
            try
            {
                _contactService.Update(contact);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpDelete("DeleteContact/{id}")]
        public IActionResult DeleteContact(int id)
        {
            try
            {
                var values = _contactService.GetById(id);
                _contactService.Destroy(values);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpDelete("DeletedStatusContact/{id}")]
        public IActionResult DeletedStatusContact(int id)
        {
            try
            {
                var values = _contactService.GetById(id);
                _contactService.Delete(values);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("GetActivesContact")]
        public IActionResult GetActivesContact()
        {
            try
            {
                var values = _contactService.GetActives();
                return Ok(values);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("GetActiveContact/{id}")]
        public IActionResult GetActiveContact(int id)
        {
            try
            {
                var values = _contactService.GetById(id);
                _contactService.GetActive(values);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("ContactInboxList")]
        public IActionResult ContactInboxList()
        {
            try
            {
                var values = _contactService.GetAll();
                return Ok(values);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("GetContactCount")]
        public IActionResult GetContactCount()
        {
            try
            {
                var values = _contactService.GetContactCount();
                return Ok(values);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
    }
}
