using ECommerce.DataAccessLayer.Concrete;
using ECommerce.EntityLayer.Concrete;
using ECommerce.WebUI.Dtos.AboutDto;
using ECommerce.WebUI.Dtos.CategoryDto;
using ECommerce.WebUI.Dtos.EmployeeDto;
using ECommerce.WebUI.Dtos.ProductDto;
using ECommerce.WebUI.ValidationRules.AboutValidationRules;
using ECommerce.WebUI.ValidationRules.CategoryValidationRules;
using ECommerce.WebUI.ValidationRules.EmployeeValidation;
using ECommerce.WebUI.ValidationRules.ProductValidationRules;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using System.Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.Web.CodeGeneration.Utils;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;
using System.Threading;
using ECommerce.WebUI.ValidationRules.AppRoleValidationRules;
using ECommerce.WebUI.Dtos.AppRoleDto;
using ECommerce.WebUI.ValidationRules.BookingValidationRules;
using ECommerce.WebUI.Dtos.BookingDto;
using ECommerce.WebUI.Dtos.LoginDto;
using ECommerce.WebUI.ValidationRules.LoginValidationRules;
using ECommerce.WebUI.Dtos.ReferanceDto;
using ECommerce.WebUI.ValidationRules.ReferanceValidationRules;
using ECommerce.WebUI.ValidationRules.RegisterValidationRules;
using ECommerce.WebUI.Dtos.RegisterDto;
using ECommerce.WebUI.ValidationRules.ShipperValidationRules;
using ECommerce.WebUI.Dtos.ShipperDto;
using ECommerce.WebUI.Dtos.SubscribeDto;
using ECommerce.WebUI.ValidationRules.SubscribeValidationRules;
using ECommerce.WebUI.Dtos.SupplierDto;
using ECommerce.WebUI.ValidationRules.SupplierValidationRules;
using ECommerce.BusinessLayer.Abstract;
using ECommerce.BusinessLayer.Concrete;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.EntityFramework;
using ECommerce.WebUI.Dtos.ContactDto;
using ECommerce.WebUI.ValidationRules.ContactValidationRules;
using ECommerce.WebUI.Dtos.OrderDto;
using ECommerce.WebUI.ValidationRules.OrderValidationRules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>(options => options.SignIn.RequireConfirmedEmail = true).AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = GoogleDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
//})
//            .AddGoogle(options =>
//            {
//                options.ClientId = "379959781910-iio79i733tqnognqlog5g648larhpk8f.apps.googleusercontent.com";
//                options.ClientSecret = "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";
//            });


builder.Services.AddScoped<IBookingService, BookingManager>();
builder.Services.AddScoped<IBookingDal, EfBookingDal>();

//-----------------------------------------------------------------------
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = GoogleDefaults.AuthenticationScheme;
//    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
//    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

//})
//.AddCookie()
//.AddGoogle(options =>
//{
//    var googleSection = builder.Configuration.GetSection("Google");
//    options.ClientId = googleSection["ClientID"];
//    options.ClientSecret = googleSection["ClientSecret"];

//}); ;
//-------------------------------------------------------------------------

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
}
)
.AddCookie()
.AddGoogle(options =>
{
    var googleSection = builder.Configuration.GetSection("Google");
    options.ClientId = googleSection["ClientID"];
    options.ClientSecret = googleSection["ClientSecret"];

});


//.AddGoogle(GoogleDefaults.AuthenticationScheme, options =>
//{
//    options.ClientId = builder.Configuration.GetSection("Authentication:Google:ClientId").Value;
//    options.ClientSecret = builder.Configuration.GetSection("Authentication:Google:CliendSecret").Value;

//});
builder.Services.AddScoped<IBookingService, BookingManager>();
builder.Services.AddScoped<IBookingDal, EfBookingDal>();
builder.Services.AddScoped<IProductDal, EfProductDal>();
builder.Services.AddScoped<IProductService, ProductManager>();

builder.Services.AddScoped<IOrderDal, EfOrderDal>();
builder.Services.AddScoped<IOrderService, OrderManager>();
builder.Services.AddScoped<IOrderDetailDal, EfOrderDetailDal>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailManager>();

//.AddGoogle(GoogleDefaults.AuthenticationScheme, options =>
//{
//    options.ClientId = builder.Configuration.GetSection("Google:ClientId").Value;
//    options.ClientSecret = builder.Configuration.GetSection("Google:ClientSecret").Value;
//});

////builder.Services.AddAuthentication().AddGoogle(options =>
////{
////    var googleSection = builder.Configuration.GetSection("Google");
////    options.ClientId = googleSection["ClientID"];
////    options.ClientSecret = googleSection["ClientSecret"];

////});


//builder.Services.Configure<CookiePolicyOptions>(options =>
//{
//    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
//    options.CheckConsentNeeded = context => true;
//    options.MinimumSameSitePolicy = SameSiteMode.None;
//});

//builder.Services.Configure<OpenIdConnectOptions>(AzureADDefaults.OpenIdScheme, options =>
//{
//    options.RemoteAuthenticationTimeout = TimeSpan.FromSeconds(10);
//    options.Events.OnRemoteFailure = RemoteAuthFail;
//});


builder.Services.AddHttpClient();
//---------------------------------------------------

builder.Services.AddTransient<IValidator<CreateCategoryDto>, CreateCategoryValidator>();
builder.Services.AddTransient<IValidator<UpdateCategoryDto>, UpdateCategoryValidator>();

builder.Services.AddTransient<IValidator<CreateAboutDto>, CreateAboutValidator>();
builder.Services.AddTransient<IValidator<UpdateAboutDto>, UpdateAboutValidator>();

builder.Services.AddTransient<IValidator<CreateProductDto>, CreateProductValidator>();
builder.Services.AddTransient<IValidator<UpdateProductDto>, UpdateProductValidator>();

builder.Services.AddTransient<IValidator<CreateEmployeeDto>, CreateEmployeeValidator>();
builder.Services.AddTransient<IValidator<UpdateEmployeeDto>, UpdateEmployeeValidator>();

builder.Services.AddTransient<IValidator<CreateAppRoleDto>, CreateAppRoleValidator>();
builder.Services.AddTransient<IValidator<UpdateAppRoleDto>, UpdateAppRoleValidator>();

builder.Services.AddTransient<IValidator<CreateBookingDto>, CreateBookingValidator>();

builder.Services.AddTransient<IValidator<LoginUserDto>, LoginUserValidator>();

builder.Services.AddTransient<IValidator<CreateReferanceDto>, CreateReferanceValidator>();
builder.Services.AddTransient<IValidator<UpdateReferanceDto>, UpdateReferanceValidator>();

builder.Services.AddTransient<IValidator<CreateNewUserDto>, CreateNewUserValidator>();

builder.Services.AddTransient<IValidator<CreateShipperDto>, CreateShipperValidator>();
builder.Services.AddTransient<IValidator<UpdateShipperDto>, UpdateShipperValidator>();

builder.Services.AddTransient<IValidator<CreateSubscribeDto>, CreateSubscribeValidator>();

builder.Services.AddTransient<IValidator<CreateSupplierDto>, CreateSupplierValidator>();
builder.Services.AddTransient<IValidator<UpdateSupplierDto>, UpdateSupplierValidator>();

builder.Services.AddTransient<IValidator<CreateContactDto>, CreateContactValidator>();

builder.Services.AddTransient<IValidator<UpdateOrderDto>, UpdateOrderValidator>();

//---------------------------------------------------
builder.Services.AddControllersWithViews().AddFluentValidation();
builder.Services.AddAutoMapper(typeof(StartupBase));

//builder.Services.Configure<CookiePolicyOptions>(options =>
//{
//    options.Secure = CookieSecurePolicy.Always;
//});
//---------------------------------------------------

builder.Services.AddMvc
    (config => { var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    config.Filters.Add(new AuthorizeFilter(policy));
    });
builder.Services.ConfigureApplicationCookie(
    options =>
    {
        options.Cookie.HttpOnly = true;
        options.ExpireTimeSpan = TimeSpan.FromDays(2);
        options.LoginPath = "/Login/Index/";
        options.Cookie.IsEssential = true;

    });

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(x =>
{
    x.IdleTimeout = TimeSpan.FromMinutes(5);
    x.Cookie.HttpOnly = true;
    x.Cookie.IsEssential = true;
});


var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

    //app.UseCookiePolicy(new CookiePolicyOptions()
    //{
    //    MinimumSameSitePolicy = SameSiteMode.Lax

    //});
}

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();

app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");
app.Run();



//An unhandled exception occurred while processing the request.
//Exception: Correlation failed.
//Unknown location

//Exception: An error was encountered while handling the remote login.
//Microsoft.AspNetCore.Authentication.RemoteAuthenticationHandler<TOptions>.HandleRequestAsync()