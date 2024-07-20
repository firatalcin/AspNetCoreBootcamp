using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ToDoAppNTier.DataAccess.Contexts;

namespace ToDoAppNTier.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<ToDoContext>(opt =>
            {
                opt.UseSqlServer("server=MAKINA\\SQLEXPRESS01; database= ToDoDb; integrated security=true;TrustServerCertificate=True");
            });
        }
    }
}
