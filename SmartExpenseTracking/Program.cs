using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SET.Infrastructure;
using SET.Repository;
using SET.Repository.Interface;
using SET.Service;
using SET.Service.Interface;

namespace SmartExpenseTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //This connects your DbContext to SQL Server.
            builder.Services.AddDbContext<SetDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SetDatabaseConnection")));

            // Configured Identity
            // Add Identity
            builder.Services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
            }).AddRoles<IdentityRole>().AddEntityFrameworkStores<SetDbContext>();

            builder.Services.AddScoped<IFaqRepository, FaqRepository>();
            builder.Services.AddScoped<IFaqService, FaqService>();

            builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();
            builder.Services.AddScoped<IExpenseService, ExpenseService>();

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

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
