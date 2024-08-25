using Authenticator.API.Hubs;
using Core.Extensions;
using Microsoft.AspNetCore.SignalR;

namespace Authenticator.API.Extensions
{
    public static class ApplicationExtensions
    {
        public static void UseInfrastructure(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment() || env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(options =>
                {
                    options.SerializeAsV2 = true;
                });
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Master data - API");
                });
            }

            // Các cấu hình khác...

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapHub<ChatHub>("/myHub"); // Định nghĩa đường dẫn cho Hub
            //                                       // Định nghĩa các endpoint khác nếu cần...
            //});

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseCors("CorsPolicy");


            //app.UseLoggingApi();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapHub<ChatHub>("/chathub");
            });

            TokenExtensions.Configure(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());
        }
    }
}
