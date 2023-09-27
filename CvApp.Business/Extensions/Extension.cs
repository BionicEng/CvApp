using AutoMapper;
using CvApp.Business.MapProfiles;
using CvApp.Business.Middlewares;
using CvApp.Data.DbContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CvApp.Business.Extensions
{
    public static class Extension
    {
        //Burada this kullandığımız için metodu çağırdığımda ServiceCollection'ı parametre olarak vermeye gerek kalmadı. Sadece confiquration verilecek.
        //public static IServiceCollection AddMyDbContext(this IServiceCollection services, IConfiguration configuration)
        //{
        //    //Veri tabanı dizesini aldım
        //    var connectionString = configuration.GetConnectionString("DefaultConnection");

        //    //DbContexti ekledim
        //    services.AddDbContext<AppDbContext>(options =>
        //        options.UseSqlServer(connectionString)
        //    );

        //    return services;

        //}
        public static IServiceCollection AddMyDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            //Veri tabanı dizesini aldım
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            //DbContexti ekledim
            services.AddDbContext<AppDbContext>(options =>
                options.UseMySQL(connectionString)
            );

            return services;

        }
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RequestLoggingMiddleware>();
        }
        public static IServiceCollection AddCustomAutoMapper(this IServiceCollection services)
        {

            var mapperConfig = new MapperConfiguration(mc =>
            {
                // AutoMapper profile
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }

        //JWT ile authorize olurken requestin cookie sine token'ı ekledik.
        public static IApplicationBuilder UseCustomAuthorization(this IApplicationBuilder app)
        {
            return app.Use(async (context, next) =>
            {
                if (context.Request.Cookies.TryGetValue("cv-app-token", out var token))
                {
                    context.Request.Headers["Authorization"] = $"Bearer {token}";
                }

                await next();
            });
        }
        public static IApplicationBuilder UseJWTDirectToLogin(this IApplicationBuilder app)
        {
            return app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 401)
                {
                    context.Response.Redirect("/Auth/Login");
                }

            });



        }
    }
}



