using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace Degage.EMS.VersionControl
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {
                var webHost = CreateWebHostBuilder(args);
                webHost.Build().Run();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Stopped program because of exception");
                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                NLog.LogManager.Shutdown();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(String[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureLogging((context, builder) =>
            {
                builder.ClearProviders();
                builder.SetMinimumLevel(LogLevel.Trace);
            })
            .UseNLog()  // NLog: setup NLog for Dependency injection
            .UseStartup<Startup>();
    }

}
