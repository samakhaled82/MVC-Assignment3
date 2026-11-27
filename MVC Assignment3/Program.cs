using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MVC_Assignment2.Context;
using MVC_Assignment2.Entities;
using MVC_Assignment2.Repositiories;
using MVC_Assignment2.Repositiories.Contract;
using MVC_Assignment2.Repositiories_Conteract;
using MVC_Assignment2.Repositiories_Conteract;
using System.Linq.Expressions;


namespace MVC_Assignment2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IPlanReposiotry, PlanReposiotry>();

            builder.Services.AddDbContext<GymDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IMembershiprepository, Membershiprepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
