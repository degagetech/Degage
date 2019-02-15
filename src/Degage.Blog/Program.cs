using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Degage.Blog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
            //test 1
        }

        public static IWebHostBuilder CreateWebHostBuilder(String[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls($"http://*:80")
                .UseStartup<Startup>();
    }
}
