using AutoMapper;
using ECommerce.EntityLayer.Concrete;
using ECommerce.WebUI.Dtos.AboutDto;
using ECommerce.WebUI.Dtos.AppRoleDto;
using ECommerce.WebUI.Dtos.AppUserDto;
using ECommerce.WebUI.Dtos.BookingDto;
using ECommerce.WebUI.Dtos.CategoryDto;
using ECommerce.WebUI.Dtos.ContactDto;
using ECommerce.WebUI.Dtos.EmployeeDto;
using ECommerce.WebUI.Dtos.LoginDto;
using ECommerce.WebUI.Dtos.OrderDto;
using ECommerce.WebUI.Dtos.ProductDto;
using ECommerce.WebUI.Dtos.ReferanceDto;
using ECommerce.WebUI.Dtos.RegisterDto;
using ECommerce.WebUI.Dtos.RoleAssignDto;
using ECommerce.WebUI.Dtos.SendingMessageDto;
using ECommerce.WebUI.Dtos.ShipperDto;
using ECommerce.WebUI.Dtos.SubscribeDto;
using ECommerce.WebUI.Dtos.SupplierDto;

namespace ECommerce.WebUI.Mapping
{
    public class AutoMapperConfig : Profile //mapping kütüphanesinin içindekileri kullanıyor demek
    {
        public AutoMapperConfig()
        {
            //--------------------------------------------------------
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductDto>().ReverseMap();
            //--------------------------------------------------------      
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();
            CreateMap<About, ResultAboutDto>().ReverseMap();
            //--------------------------------------------------------             
            CreateMap<Referance, CreateReferanceDto>().ReverseMap();
            CreateMap<Referance, UpdateReferanceDto>().ReverseMap();
            CreateMap<Referance, ResultReferanceDto>().ReverseMap();
            //--------------------------------------------------------
            CreateMap<Employee, CreateEmployeeDto>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeDto>().ReverseMap();
            CreateMap<Employee, ResultEmployeeDto>().ReverseMap();
            CreateMap<Employee, ResultLastFourEmployeeDto>().ReverseMap();
            //--------------------------------------------------------
            CreateMap<Subscribe, CreateSubscribeDto>().ReverseMap();
            //--------------------------------------------------------
            CreateMap<Booking, CreateBookingDto>().ReverseMap();
            CreateMap<Booking, ResultBookingDto>().ReverseMap();
            //--------------------------------------------------------
            CreateMap<AppUser, CreateNewUserDto>().ReverseMap();
            CreateMap<AppUser, LoginUserDto>().ReverseMap();
            //--------------------------------------------------------
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, InboxContactDto>().ReverseMap();
            CreateMap<Contact, GetMessageByIdDto>().ReverseMap();
            //--------------------------------------------------------
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            //--------------------------------------------------------
            CreateMap<SendingMessage, CreateSendMessageDto>().ReverseMap();
            CreateMap<SendingMessage, ResultSendboxDto>().ReverseMap();
            //--------------------------------------------------------                       
            CreateMap<AppUser, ResultAppUserDto>().ReverseMap();
            CreateMap<AppUser, ResultAppUserListDto>().ReverseMap();
            //--------------------------------------------------------
            CreateMap<AppRole, CreateAppRoleDto>().ReverseMap();
            CreateMap<AppRole, UpdateAppRoleDto>().ReverseMap();
            //--------------------------------------------------------
            CreateMap<Shipper, CreateShipperDto>().ReverseMap();
            CreateMap<Shipper, ResultShipperDto>().ReverseMap();
            CreateMap<Shipper, UpdateShipperDto>().ReverseMap();
            //--------------------------------------------------------
            CreateMap<Supplier, CreateSupplierDto>().ReverseMap();
            CreateMap<Supplier, UpdateSupplierDto>().ReverseMap();
            CreateMap<Supplier, ResultSupplierDto>().ReverseMap();
            //--------------------------------------------------------           
            CreateMap<Order, ResultOrderDto>().ReverseMap();
            CreateMap<Order, ResultLastFourOrderDto>().ReverseMap();
            CreateMap<Order, UpdateOrderDto>().ReverseMap();
            //--------------------------------------------------------
            CreateMap<AppRole, RoleAssignDto>().ReverseMap();
        }
    }
}
