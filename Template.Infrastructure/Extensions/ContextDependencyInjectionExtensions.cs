using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Template.Application.Configuration.Data;
using Template.Infrastructure.Persistence;

namespace Template.Infrastructure.Extensions
{
    public static class ContextDependencyInjectionExtensions
    {
        public static IServiceCollection AddContextDI(this IServiceCollection services,string connection_string)
        {
            //register dbcontext 
            services.AddDbContext<TemplateDbContext>(options =>
                options.UseSqlServer(connection_string));
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<TemplateDbContext>());

            return services;
        }
    }
}
