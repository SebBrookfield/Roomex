using Roomex.Distance.Calculator.Factories;
using Roomex.Distance.Calculator.Services;

namespace Roomex.Distance.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder.Services);
            
            var app = builder.Build();
            app.MapControllers();
            app.Run();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IDistanceCalculatorFactory, DistanceCalculatorFactory>();
            services.AddSingleton<ILengthConverterFactory, LengthConverterFactory>();
            services.AddSingleton<IDistanceCalculatorService, DistanceCalculatorService>();
        }
    }
}