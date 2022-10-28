using AutoMapper;
using Ecommerce.Core.Data;
using Ecommerce.Shared.Domain;
using Ecommerce.Shared.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuration of mapper

builder.Services.AddCors(o => o.AddPolicy("AdminfierPolicy", x =>
  {
      x.AllowAnyHeader();
      x.AllowAnyMethod();
      x.AllowAnyOrigin();
  }));


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var config = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<AdminModel, AdminDomain>().ReverseMap();
    cfg.CreateMap<SubCategoryModel, SubCategoryDomain>().ReverseMap();
    cfg.CreateMap<UserModel, UserDomain>().ReverseMap();
    cfg.CreateMap<CategoryModel, CategoryDomain>().ReverseMap();
    cfg.CreateMap<ProductModel, ProductDomain>().ReverseMap();
    cfg.CreateMap<CompanyModel, CompanyDomain>().ReverseMap();


});
builder.Services.AddSingleton(config.CreateMapper());




// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("con"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("AdminfierPolicy");
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
