using Microsoft.EntityFrameworkCore;
using Pdk2410900044_exam.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("PdkStudent2410900044DbContext")
	?? throw new InvalidOperationException("Connection string 'PdkStudent2410900044DbContext' not found.");

builder.Services.AddDbContext<PdkStudent2410900044DbContext>(options =>
	options.UseSqlServer(connectionString));

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();