using Template.Application.Features.Movie.Usecase;
using Template.Application.Services.Local_Services;
using Template.Infrastructure.Services.Local_Services;
using Template.Application.Services.LocalServices;
using Template.Infrastructure.Services.LocalServices;

namespace Template.API.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddFeatureLocalServices(this IServiceCollection services)
        {
            //service register 
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IDateTimeService, DateTimeService>();
            services.AddScoped<IHashingService,HashingService>();
            return services;
        }
        public static IServiceCollection AddFeatureUseCases(this IServiceCollection services)
        {
            //Usecase Register
            services.AddScoped<IMovieUsecases, MovieUsecases>();

            return services;
        }
    }
}
