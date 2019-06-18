using System;
using System.Collections.Generic;
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
            var connectionStringSection = Configuration.GetSection("ConnectionString");
            var mainConnStr = connectionStringSection.GetValue<String>("Main");
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
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}
