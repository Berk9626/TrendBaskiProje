namespace ECommerce.WebUI.Models.EmployeWithImage
{
    public class EmpWithFile
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public EmpWithFile(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string GetFilePath(string EmployeeName)
        {
            return _webHostEnvironment.WebRootPath + "\\employeeImages\\" + EmployeeName;
        }

        public string GetImagebyEmployee(string employeename)
        {
            string ImageUrl = string.Empty;
            string HostUrl = "http://localhost:45318/";
            string Filepath = GetFilePath(employeename);

            //if (!System.IO.File.Exists(Filepath))
            //{
            //    ImageUrl = HostUrl + "/uploads/common/noimage.png";
            //}
            return ImageUrl = HostUrl + "/employeeImages/" + employeename;


        }
    }
}
