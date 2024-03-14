using Core.Commons;
using NetCore.AutoRegisterDi;
using System.Text;

namespace Authenticator.API.Extensions.Configures
{
    public class CommonConfig
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Register code
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            //Auto DI with EndName: Query
            services
            .RegisterAssemblyPublicNonGenericClasses(DIAssemblies.AssembliesToScan)
                .Where(t => t.Name.EndsWith("Query"))
                .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);

            //Auto DI with EndName: Service
            services
            .RegisterAssemblyPublicNonGenericClasses(DIAssemblies.AssembliesToScan)
                .Where(t => t.Name.EndsWith("Service"))
                .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);

            //Auto DI with EndName: Handler
            services
            .RegisterAssemblyPublicNonGenericClasses(DIAssemblies.AssembliesToScan)
                .Where(t => t.Name.EndsWith("Handler"))
                .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);

            // Inject IRepository
            //services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

            // Inject UnitOfWork
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        }
    }
}
