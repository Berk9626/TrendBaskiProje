using ECommerce.BusinessLayer.Abstract;
using ECommerce.BusinessLayer.Concrete;
using ECommerce.BusinessLayer.Repositories.Abstract;
using ECommerce.BusinessLayer.Repositories.Concrete;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.Concrete;
using ECommerce.DataAccessLayer.EntityFramework;
using ECommerce.DataAccessLayer.Repositories.Abstract;
using ECommerce.DataAccessLayer.Repositories.Concretes;
using ECommerce.EntityLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(
options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true).AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling= Newtonsoft.Json.ReferenceLoopHandling.Ignore);
//-----------------------------------------------------------------
builder.Services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<>), typeof(BaseManager<>));
builder.Services.AddScoped<IAboutDal,EfAboutDal>();
builder.Services.AddScoped<IAppUserDal, EfAppUserDal>();
builder.Services.AddScoped<IAppUserProfileDal, EfAppUserProfileDal>();
builder.Services.AddScoped<IBookingDal,EfBookingDal>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<IContactDal,EfContactDal>();
builder.Services.AddScoped<IEmployeeDal,EfEmployeeDal>();
builder.Services.AddScoped<IGuestDal,EfGuestDal>();
builder.Services.AddScoped<IOrderDetailDal,EfOrderDetailDal>();
builder.Services.AddScoped<IOrderDal,EfOrderDal>();
builder.Services.AddScoped<IProductDal,EfProductDal>();
builder.Services.AddScoped<IReferanceDal,EfReferanceDal>();
builder.Services.AddScoped<ISubscribeDal, EfSubscribeDal>();
builder.Services.AddScoped<IShipperDal, EfShipperDal>();
builder.Services.AddScoped<ISupplierDal, EfSupplierDal>();
builder.Services.AddScoped<ISendingMessageDal, EfSendingMessageDal>();
//-----------------------------------------------------------------
builder.Services.AddScoped<IAboutService,AboutManager>();
builder.Services.AddScoped<IAppUserService,AppUserManager>();
builder.Services.AddScoped<IAppUserProfileService,AppUserProfileManager>();
builder.Services.AddScoped<IBookingService,BookingManager>();
builder.Services.AddScoped<ICategoryService,CategoryManager>();
builder.Services.AddScoped<IContactService,ContactManager>();
builder.Services.AddScoped<IEmployeeService,EmployeeManager>();
builder.Services.AddScoped<IGuestService,GuestManager>();
builder.Services.AddScoped<IOrderDetailService,OrderDetailManager>();
builder.Services.AddScoped<IOrderService,OrderManager>();
builder.Services.AddScoped<IProductService,ProductManager>();
builder.Services.AddScoped<IReferanceService,ReferanceManager>();
builder.Services.AddScoped<ISubscribeService,SubscribeManager>();
builder.Services.AddScoped<IShipperService,ShipperManager>();
builder.Services.AddScoped<ISupplierService,SupplierManager>();
builder.Services.AddScoped<ISendingMessageService, SendingMessageManager>();
//-----------------------------------------------------------------
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(StartupBase));
//-----------------------------------------------------------------



builder.Services.AddCors(opt =>
{
    opt.AddPolicy("EcommerceAPI", opts =>
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); //you can get permission every header,method, and more, consume edeceðim alanlar

    });
}); //a api can use by another api or some other platforms. We get the permission it


//builder.Services.AddDistributedMemoryCache();
//builder.Services.AddSession(x =>
//{
//    x.IdleTimeout = TimeSpan.FromMinutes(5);
//    x.Cookie.HttpOnly = true;
//    x.Cookie.IsEssential = true;
//});
//-----------------------------------------------------------------
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseHttpsRedirection();
app.MapControllers();
app.UseRouting();
app.UseCors("EcommerceAPI");
app.UseAuthorization();
//app.UseSession();
app.Run();
