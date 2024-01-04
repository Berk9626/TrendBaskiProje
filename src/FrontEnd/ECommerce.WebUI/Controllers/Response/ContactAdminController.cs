using ECommerce.WebUI.Dtos.ContactDto;
using ECommerce.WebUI.Dtos.EmployeeDto;
using ECommerce.WebUI.Dtos.SendingMessageDto;
using ECommerce.WebUI.Models;
using ECommerce.WebUI.Models.MailViewModel;
using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;
using MimeKit;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace ECommerce.WebUI.Controllers.Response
{
    [Authorize(Roles = "Admin")]
    public class ContactAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> Inbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:59815/api/Contact");
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("http://localhost:59815/api/Contact/GetContactCount");
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("http://localhost:59815/api/SendingMessage/GetSendingMessageCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                ViewBag.ContactCount = jsonData2.FirstOrDefault();
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                ViewBag.SendingMessageCount = jsonData3.FirstOrDefault();
                return View(values);               
            }         
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> Sendbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:59815/api/SendingMessage");
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("http://localhost:59815/api/Contact/GetContactCount");
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("http://localhost:59815/api/SendingMessage/GetSendingMessageCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSendboxDto>>(jsonData);
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync(); 
                ViewBag.ContactCount = jsonData2.FirstOrDefault();
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync(); 
                ViewBag.SendingMessageCount = jsonData3.FirstOrDefault();
                return View(values);
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        //[HttpGet]
        public async Task<IActionResult> MessageDetailsBySendbox(int id)
        {
           
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:59815/api/SendingMessage/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetMessageByIdDto>(jsonData);
                return View(values);
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        //[HttpGet]
        public async Task<IActionResult> MessageDetailsByInbox(int id)
        {
            
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:59815/api/Contact/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<InboxContactDto>(jsonData);
                return View(values);
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        [HttpGet]
        public IActionResult AddSendMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSendMessage(CreateSendMessageDto model)
        {
            model.SenderMail = "admin@gmail.com";
            model.SenderName = "Admin";
            model.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:59815/api/SendingMessage", content);

            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddress = new MailboxAddress("Trend Baskı", "trendbaskidestek@gmail.com");
            mimeMessage.From.Add(mailboxAddress);
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", model.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);
            var bodybuilder = new BodyBuilder();
            bodybuilder.TextBody = model.Content;
            mimeMessage.Body = bodybuilder.ToMessageBody();
            mimeMessage.Subject = model.Title;
           

            SmtpClient client2 = new SmtpClient();
            client2.Connect("smtp.gmail.com", 587, false);
            client2.Authenticate("trendbaskidestek@gmail.com", "ehzg gmvm gcok tsud");
            client2.Send(mimeMessage);
            client2.Disconnect(true);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Sendbox");
            }

            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public PartialViewResult SidebarAdminContactPartial()
        {           
            return PartialView();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public PartialViewResult SidebarAdminContactCategoryPartial()
        {
            return PartialView();
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
}
