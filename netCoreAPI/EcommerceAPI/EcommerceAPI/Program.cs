global using Ecommerce.Core.Data;
global using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Ecommerce.Core.Providers;
using Ecommerce.Shared.Domain;
using Ecommerce.Shared.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var config = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<AdminModel, AdminDomain>().ReverseMap();
    cfg.CreateMap<SubCategoryModel, SubCategoryDomain>().ReverseMap();
    cfg.CreateMap<UserModel, UserDomain>().ReverseMap();
    cfg.CreateMap<CategoryModel, CategoryDomain>().ReverseMap();
    cfg.CreateMap<ProductModel, ProductDomain>().ReverseMap();
    cfg.CreateMap<CompanyModel, CompanyDomain>().ReverseMap();
    cfg.CreateMap<BrandModel, BrandDomain>().ReverseMap();
});
builder.Services.AddSingleton(config.CreateMapper());
builder.Services.AddScoped<IAdminProvider, AdminProvider>();
builder.Services.AddScoped<ICategoryProvider, CategoryProvider>();
builder.Services.AddScoped<IUserProvider, UserProvider>();
builder.Services.AddScoped<ICompanyProvider, CompanyProvider>();
builder.Services.AddScoped<IProductProvider, ProductProvider>();
builder.Services.AddScoped<ISubCategoryProvider, SubCategoryProvider>();
builder.Services.AddScoped<IWishListProvider, WishListProvider>();
builder.Services.AddScoped<ICartProvider,CartProvider>();
builder.Services.AddScoped<IBrandProvider, BrandProvider>();
builder.Services.AddScoped<IOrderProvider, OrderProvider>();

builder.Services.AddControllers();
// Add services to the container.
builder.Services.AddCors(o => o.AddPolicy("AdminfierPolicy", x =>
{
    x.AllowAnyHeader();
    x.AllowAnyMethod();
    x.AllowAnyOrigin();
}));


builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("con"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AdminfierPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
