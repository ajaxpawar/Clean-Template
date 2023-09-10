namespace Template.API.Extensions
{
    public static class APIDependencyInjectionExtensions
    {
        public static IServiceCollection AddSwaggerDI(this IServiceCollection services)
        {
            services.AddSwaggerGen();

            return services;
        }
    }
}
