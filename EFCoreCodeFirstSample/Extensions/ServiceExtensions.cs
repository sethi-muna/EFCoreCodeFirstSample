using EFCoreCodeFirstSample.DataLayer;
using EFCoreCodeFirstSample.Models;
using EFCoreCodeFirstSample.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using JavaScriptEngineSwitcher.V8;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using React.AspNet;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace EFCoreCodeFirstSample.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureMVCController(this IServiceCollection services)
        {
            services.AddControllers().AddSessionStateTempDataProvider();
            //services.AddControllersWithViews();
        }

        public static void  ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddScoped<EFCoreCodeFirstSample.LoggerServices.ILoggerServices, EFCoreCodeFirstSample.LoggerServices.LoggerServices>();
        }

        public  static void ConfigureSQLContext(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<EmployeesContext>(option => option.UseSqlServer(configuration["ConnectionStrings:sqlConnection"]));
        }

        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped<IDataRepository<Employees>, EmployeeDataManagement>();
        }
        
        public static void ConfigureReactJs(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddReact();
            services.AddJsEngineSwitcher(options =>
            {
                options.DefaultEngineName = V8JsEngine.EngineName;
                options.EngineFactories.AddV8();
            });
        }
        
        public static void ConfigureCors(this IServiceCollection services,string MyAllowSpecificOrigins)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
                                  });
            });
        }
        
        public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var authAppsettings = configuration.GetSection("Authentication");
            services.Configure<AppSettings>(authAppsettings);

            //Jwt Authentiction
            var appSettings = authAppsettings.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Key);

            services.AddAuthentication(au => {                
                au.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                au.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;                
            }).AddJwtBearer(jwt => {
                jwt.RequireHttpsMetadata = false;
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
    }
}
