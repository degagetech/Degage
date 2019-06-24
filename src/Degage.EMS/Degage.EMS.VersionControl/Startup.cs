using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Degage.DataModel.Orm;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Degage.EMS.VersionControl
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                //若要启用 Session 则此委托应该返回 false，避免检查需要 
                //EU General Data Protection Regulation (GDPR) support in ASP.NET Core
                //详情参见：https://docs.microsoft.com/en-us/aspnet/core/security/gdpr?view=aspnetcore-2.2
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            //添加数据访问服务
            String mainConnStr = null;
#if DEBUG
            var dbPath = Path.Combine(AppContext.BaseDirectory,"Db", "project-infos.db");
            mainConnStr = $"Data Source={dbPath};UTF8Encoding=True;";
#endif

#if RELEASE
            var connectionStringSection = Configuration.GetSection("ConnectionString");
             mainConnStr = connectionStringSection.GetValue<String>("ProjectInfo");
#endif
            if (String.IsNullOrWhiteSpace(mainConnStr))
            {
                throw new Exception("Configuration is invaild:DB Connection string is not found!");
            }
            var defaultDbProvider = new SQLiteDbProvider(WellKnownDataAreas.Default, mainConnStr);
            services.AddDataAccessService((area, options) =>
            {
                switch (area)
                {
                    case WellKnownDataAreas.Default:
                    default:
                        {
                            options.DbProvider = defaultDbProvider;
                        }
                        break;
                }
            });

            FileManagerConfig config = FileManagerConfig.Load("FileManagerConfig.json");
            FileManager filesManager = new FileManager(config);
            services.AddSingleton(typeof(FileManager), (p) =>
            {
                var manager = new FileManager(config);
                manager.Load();
                return manager;
            });

            services.AddSingleton<IdentifyFactory>((p) =>
            {
                IdentifyFactory identifyFactory = new IdentifyFactory();
                return identifyFactory;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            //app.UseMvc();
            app.UseMvcWithDefaultRoute();
        }
    }
}
