using Microsoft.EntityFrameworkCore;
using PdkLab12Bai1234.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Khai báo PdkDbContext
builder.Services.AddDbContext<PdkDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("PdkConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Cấu hình Route mặc định
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=PdkHome}/{action=PdkIndex}/{id?}");

app.Run();