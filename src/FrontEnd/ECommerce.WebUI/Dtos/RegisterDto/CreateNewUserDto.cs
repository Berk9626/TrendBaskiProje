using ECommerce.EntityLayer.Concrete;
using ECommerce.EntityLayer.Enums;
using ECommerce.EntityLayer.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.WebUI.Dtos.RegisterDto
{
    public class CreateNewUserDto : BaseEntity
    {
        
        public string? Name { get; set; }
        
        public string? Surname { get; set; }
        
        public string? UserName { get; set; }
        
        public string? Mail { get; set; }
        
        public string? Password { get; set; }
        
        public string? ConfirmPassword { get; set; }       
    }
}
