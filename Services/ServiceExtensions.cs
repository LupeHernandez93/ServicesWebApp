using Microsoft.EntityFrameworkCore;
using ServicesWebApp.Entities.PortalWebApp;
using ServicesWebApp.Interfaces.PortalWebApp;
using ServicesWebApp.Repository.PortalWebApp;
using ServicesWebApp.Entities.SupplierWebApp;
using ServicesWebApp.Repository.SupplierWebApps;
using ServicesWebApp.Interfaces.SupplierWebApp;
using System.ComponentModel;
using System.Reflection;

namespace ServicesWebApp.Services
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["ConnectionStrings:PortalConnection"];
            services.AddDbContext<PortalRepositoryContext>(options => options.UseSqlServer(connectionString));

            var supplierConnectionString = config["ConnectionStrings:SupplierConnection"];
            services.AddDbContext<SupplierAppRepositoryContext>(options => options.UseSqlServer(supplierConnectionString));
        }
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<ISupplierAppRepositoryWrapper, SupplierAppRepositoryWrapper>();
            services.AddScoped<IPortalRepositoryWrapper, PortalRepositoryWrapper>();
        }
        public static string ToDescription<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);
            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }
    }
}