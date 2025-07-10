using GlucoseMonitor.Application.Services;
using GlucoseMonitor.Domain.Interfaces;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                services.AddHostedService<Worker>();
                services.AddSingleton<IMeasurementProcessor, MeasurementProcessor>();

                services.AddSingleton<IMeasurementRepository, MeasurementRepository>();
                // Voeg andere dependencies toe zoals config of logger
            });
}