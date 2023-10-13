using Microsoft.EntityFrameworkCore;
using SampleCommerce.Repositories;
using SampleCommerce.Services;
using SampleEcommerce.Examples;
using SampleEFCore.Databases;
using SMECommerce.Repositories.Abstractions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<SampleCommerceDbContext>(options =>
//{

//    string connectionString = "Server=(local);Database=SampleCommerceDb; Integrated Security=true";
//    options.UseSqlServer(connectionString);
//}); 

builder.Services.AddSingleton<SampleCommerceDbContext>();


// dependency resolving mechanisms

builder.Services.AddSingleton<ICategoryService, CategoryService>();
builder.Services.AddSingleton<ICategoryRepository, CategoryRepository>();

builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();

builder.Services.AddTransient<ICategoryResolver, CategoryResolver>();



//----------------------------------------------
var app = builder.Build();
//-----------------------------------------------

// Configure the HTTP request pipeline.

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
