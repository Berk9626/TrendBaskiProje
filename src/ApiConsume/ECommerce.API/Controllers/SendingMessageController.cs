using ECommerce.BusinessLayer.Abstract;
using ECommerce.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendingMessageController : ControllerBase
    {
        private readonly ISendingMessageService _sendingMessageService;
        public SendingMessageController(ISendingMessageService sendingMessageService)
        {
            _sendingMessageService = sendingMessageService;
        }
        //---------------------------------------------------------
        [HttpGet]
        public IActionResult SendingMessageList()
        {
            try
            {
                var values = _sendingMessageService.GetAll();
                return Ok(values);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("{id}")]
        public IActionResult GetSendingMessage(int id)
        {
            try
            {
                var model = _sendingMessageService.GetById(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpPost]
        public IActionResult AddSendingMessage(SendingMessage sendingMessage)
        {
            try
            {
                _sendingMessageService.Add(sendingMessage);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpPut]
        public IActionResult UpdateSendingMessage(SendingMessage sendingMessage)
        {
            try
            {
                _sendingMessageService.Update(sendingMessage);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpDelete("DeleteSendingMessage/{id}")]
        public IActionResult DeleteSendingMessage(int id)
        {
            try
            {
                var values = _sendingMessageService.GetById(id);
                _sendingMessageService.Destroy(values);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpDelete("DeletedStatusSendingMessage/{id}")]
        public IActionResult DeletedStatusSendingMessage(int id)
        {
            try
            {
                var values = _sendingMessageService.GetById(id);
                _sendingMessageService.Delete(values);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("GetActivesSendingMessage")]
        public IActionResult GetActivesSendingMessage()
        {
            try
            {
                var values = _sendingMessageService.GetActives();
                return Ok(values);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("GetActiveSendingMessage/{id}")]
        public IActionResult GetActiveSendingMessage(int id)
        {
            try
            {
                var values = _sendingMessageService.GetById(id);
                _sendingMessageService.GetActive(values);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("GetSendingMessageCount")]
        public IActionResult GetSendingMessageCount()
        {
            try
            {
                return Ok(_sendingMessageService.GetSendingMessageCount());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
    }
}
