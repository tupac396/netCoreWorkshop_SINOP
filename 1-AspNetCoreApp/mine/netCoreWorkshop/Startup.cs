using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;

namespace netCoreWorkshop
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "defaul",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            });
            app.UseStaticFiles();

            app.Run(context => context.Response.WriteAsync("Que onda cabron, from ASP.NET!"));
            
        }

        public void ConfigureServices(IServiceCollection services){
            services.AddControllersWithViews();
        }
    }
}