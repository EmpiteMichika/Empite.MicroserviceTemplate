using Empite.Template;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;

namespace Empite.MicroserviceTemplate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile("Opt/Conf/config.json", optional: true, reloadOnChange: true);
                    config.AddEnvironmentVariables();
                    Log.Logger = new LoggerConfiguration()
                        .Enrich.FromLogContext()
                        .WriteTo.Console(LogEventLevel.Information)
                        .WriteTo.RollingFile("Opt/Logs/log-{Date}.txt", fileSizeLimitBytes: null)
                        .CreateLogger();
                })
                .ConfigureLogging((hostingContext, logging) => { logging.AddSerilog(dispose: true); })
                .UseStartup<Startup>()
                .Build();
    }
}
