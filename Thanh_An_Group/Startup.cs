using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThanhAn_group.BLL.IService;
using ThanhAn_group.BLL.Service;
using ThanhAn_Group.DAL.Data;

namespace Thanh_An_Group
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddControllers();
            services.AddControllers().AddXmlSerializerFormatters();
            

            services.AddControllersWithViews();

            services.AddDbContext<ThanhAn_GroupContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MotoContext")));

            services.AddScoped<IAdministrator_Service, Administrator_Service>();
            services.AddScoped<IBaiViet_Services, BaiViet_Service>();
            services.AddScoped<IGallVideo_Service, GalleriesVideo_Service>();
            services.AddScoped<IGallImages_Service, GallImages_Service>();
            services.AddScoped<ISlide_Service, Slide_Service>();
            services.AddScoped<IDoi_Tac_Service, Doi_Tac_Service>();
            services.AddSession();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseSession();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                

            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "Admin",
                  pattern: "{area:exists}/{controller=TrangChu}/{action=Index}/{id?}"
                );
            });

        }
    }
}
