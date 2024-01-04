using System.ComponentModel.DataAnnotations;


namespace ECommerce.WebUI.Dtos.LoginDto
{
    public class LoginUserDto
    {        
        public string UserName { get; set; }       
        public string Password { get; set; }
    }
}
