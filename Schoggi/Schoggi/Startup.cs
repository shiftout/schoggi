using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Schoggi.Data;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace Schoggi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IWebHostEnvironment Env { get; set; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = services.AddRazorPages();

            //services.AddDbContext<SchoggiContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SchoggiContext")));
            services.AddDbContext<SchoggiContext>(options => options.UseInMemoryDatabase("InMemoryDb"));

            var physicalProvider = new PhysicalFileProvider(Path.GetTempPath());
            //var physicalProvider = new PhysicalFileProvider(Configuration.GetValue<string>("StoredFilesPath"));
            services.AddSingleton<IFileProvider>(physicalProvider);

            if (Env.IsDevelopment())
            {
                builder.AddRazorRuntimeCompilation();
            }
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
