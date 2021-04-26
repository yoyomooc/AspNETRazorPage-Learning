using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using YoYoMooc.StudentManagement.Services;

namespace YoYoMooc.StudentManagement.RazorPage
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
            services.AddRazorPages();
            services.AddSingleton<IStudentRepository, MockStudentRepository>();

            services.Configure<RouteOptions>(options =>
            {
                //如果你希望URL中的查询字符串为小写
                //就需要将LowercaseUrls为true，默认值为false
                options.LowercaseUrls = true;
                //LowercaseQueryStrings的值也需要设置为true,默认值为false
                options.LowercaseQueryStrings = true;
                //  在生成的URL后面附加一个斜杠
                options.AppendTrailingSlash = true;
 
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
