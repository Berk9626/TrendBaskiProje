using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Models.ProductWithFile
{
    public  class PrWithFile
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PrWithFile(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string GetFilePath(string ProductName)
        {
            return _webHostEnvironment.WebRootPath + "\\productImages\\" + ProductName;
        }
       
        public string GetImagebyProduct(string productname)
        {
            string ImageUrl = string.Empty;
            string HostUrl = "http://localhost:45318/";
            string Filepath = GetFilePath(productname);
            //string Imagepath = Filepath + "\\image.png";
            //if (!System.IO.File.Exists(Filepath))
            //{
            //    ImageUrl = HostUrl + "/uploads/common/noimage.png";
            //}
            ImageUrl = HostUrl + "/productImages/" + productname /*+ "/image.png"*/;
            return ImageUrl;
            
            
        }
    }
}
