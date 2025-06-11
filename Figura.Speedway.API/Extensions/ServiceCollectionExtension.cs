using Figura.Speedway.Model;
using Figura.Speedway.ResultsApiReader;
using Figura.Speedway.Service;
using Figura.SpeedwayRider.DataContract;

namespace Speedway.API.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection IncludeSpeedwayDb(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration
                .GetSection("ConnectionStrings")
                .GetSection("Figura.Speedway")
                .Get<string>()!;

            return services.AddTransient<SpeedwayDb>(x => new SpeedwayDb(connectionString));
        }

        public static IServiceCollection IncludeSpeedwayService(this IServiceCollection services)
        {
            return services.AddTransient<ISpeedwayService, SpeedwayService>();
        }

        public static IServiceCollection IncludeRiderServcie(this IServiceCollection services)
        {
            return services.AddTransient<IRiderDataService, RiderDataService>();
        }

        public static IServiceCollection IncludeApiReader(this IServiceCollection services)
        {
            return services.AddTransient<IApiReaderManager, ApiReaderManager>();
        }
    }
}
