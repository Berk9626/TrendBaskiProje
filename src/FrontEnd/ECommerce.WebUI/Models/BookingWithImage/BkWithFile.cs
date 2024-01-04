namespace ECommerce.WebUI.Models.BookingWithImage
{
    public class BkWithFile
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BkWithFile(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string GetFilePath(string BookingName)
        {
            return _webHostEnvironment.WebRootPath + "\\bookingImages\\" + BookingName;
        }

        public string GetImagebyBooking(string bookingname)
        {
            string ImageUrl = string.Empty;
            string HostUrl = "http://localhost:45318/";
            string Filepath = GetFilePath(bookingname);

            //if (!System.IO.File.Exists(Filepath))
            //{
            //    ImageUrl = HostUrl + "/uploads/common/noimage.png";
            //}
            return ImageUrl = HostUrl + "/bookingImages/" + bookingname;


        }
    }
}
