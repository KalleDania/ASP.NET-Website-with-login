using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;  // login
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using _18Marts.Entities;
using _18Marts.Data;
using _18Marts.Services;

namespace _18Marts
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment _env)
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true);

            if (_env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<VideoDbContext>(options => options.UseSqlServer(connectionString));

            services.AddMvc();

            services.AddSingleton(provider => Configuration);
            services.AddSingleton<IMessageService, ConfigurationMessageService>();
            //services.AddSingleton<IVideoData, SqlVideoData>(); Denne her skulle vi egentligt bruge istedet for den under, men får en fejl når jeg gør det. Kigger på det senere. Evt tag en klasse af gangen her fra og pårøv og replace med disse https://github.com/csharpschool/AspNetCoreVideoCore/tree/master/AspNetCoreVideoCore
            services.AddSingleton<IVideoData, MockVideoData>();
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<VideoDbContext>();  // login
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IMessageService _msg)
        {

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }


            app.UseStaticFiles();
            app.UseIdentity(); // login
            app.UseFileServer();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.Run(async (context) =>
            {
                //throw new Exception("Fake Exception!");
                await context.Response.WriteAsync(_msg.GetMessage());
            });
        }
    }
}
