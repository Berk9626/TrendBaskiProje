using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.ViewComponent.Dashboard
{
    public class _DashboardWidgetODPartial : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DashboardWidgetODPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:59815/api/OrderDetail/GetTotalRevenueCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.GetTotalCount = jsonData;

            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("http://localhost:59815/api/OrderDetail/GetMonthlyRevenue");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.GetMonthlyCount = jsonData2;

            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("http://localhost:59815/api/OrderDetail/GetWeeklyRevenue");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.GetWeeklyCount = jsonData3;

            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("http://localhost:59815/api/OrderDetail/GetDailyRevenue");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.GetDailyCount = jsonData4;
            return View();
        }
    }
}
