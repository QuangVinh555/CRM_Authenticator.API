using Authenticator.API.Extensions.Configures;
using Core.Exceptions;
using Core.Extensions;
using Infrastructure.Entites;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Authenticator.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddJWTTokenServices(configuration);

            //MediatR
            services.AddMediatR(DIAssemblies.AssembliesToScan);

            //Auto mapper
            //services.AddAutoMapper(DIAssemblies.AssembliesToScan);

            // Swagger Config
            SwaggerConfig.Configure(services, configuration);

            //Common config
            CommonConfig.Configure(services, configuration);

            // SignalR
            services.AddSignalR();

            services.AddHttpContextAccessor();

            //Global filter
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(HttpGlobalExceptionFilter));
            });

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<CRMContext>(options => options.UseSqlServer(connectionString));
            services.AddApiVersioning();

            return services;
        }

        public static void ConfigureCors(this IServiceCollection services, IConfiguration configuration)
        {
            var origins = configuration.GetValue<string>("AllowedOrigins").Split(";");
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.WithOrigins(origins)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials() // Cho phép sử dụng các credentials từ origin cụ thể
                        .WithExposedHeaders("Access-Control-Allow-Origin"); // Chỉ định header được tiết lộ
                });
            });
        }
    }
}
