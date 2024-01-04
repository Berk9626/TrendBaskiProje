namespace ECommerce.WebUI.Models.ReferanceWithImage
{
    public class RefWithFile
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public RefWithFile(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string GetFilePath(string ReferanceName)
        {
            return _webHostEnvironment.WebRootPath + "\\referanceImages\\" + ReferanceName;
        }

        public string GetImagebyReferance(string referancename)
        {
            string ImageUrl = string.Empty;
            string HostUrl = "http://localhost:45318/";
            string Filepath = GetFilePath(referancename);

            //if (!System.IO.File.Exists(Filepath))
            //{
            //    ImageUrl = HostUrl + "/uploads/common/noimage.png";
            //}
            return ImageUrl = HostUrl + "/referanceImages/" + referancename;


        }
    }
}
