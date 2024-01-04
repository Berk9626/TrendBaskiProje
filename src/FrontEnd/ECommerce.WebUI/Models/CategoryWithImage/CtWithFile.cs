namespace ECommerce.WebUI.Models.CategoryWithFile
{
    public class CtWithFile
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CtWithFile(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string GetFilePath(string CategoryName)
        {
            return _webHostEnvironment.WebRootPath + "\\categoryImages\\" + CategoryName;
        }

        public string GetImagebyCategory(string categoryname)
        {
            string ImageUrl = string.Empty;
            string HostUrl = "http://localhost:45318/";
            string Filepath = GetFilePath(categoryname);
            //if (!System.IO.File.Exists(Filepath))
            //{
            //    ImageUrl = HostUrl + "/uploads/common/noimage.png";
            //}

            return ImageUrl = HostUrl + "/categoryImages/" + categoryname;


        }
    }
}
