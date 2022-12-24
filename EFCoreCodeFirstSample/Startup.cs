using EFCoreCodeFirstSample.Extensions;
using EFCoreCodeFirstSample.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using React.AspNet;
using System;
using System.Text;

namespace EFCoreCodeFirstSample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureReactJs();
            services.ConfigureMVCController();
            services.ConfigureLoggerService();
            services.ConfigureSQLContext(Configuration);
            services.ConfigureRepository();
            services.ConfigureCors(MyAllowSpecificOrigins);
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.ConfigureJwt(Configuration);
            services.AddScoped<IAuthenticateService, AuthenticateService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapDefaultControllerRoute();
            //    //endpoints.MapControllerRoute("default", "{controller=Index}/{action=Index}/{id?}");
            //});
            app.UseCors(MyAllowSpecificOrigins);
            
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            ////Add the ReactJS File.
            //app.UseReact(config =>
            //{
            //    config.AddScript("~/Scripts/main.jsx");
            //});
            app.UseStaticFiles();

        }
    }
}
