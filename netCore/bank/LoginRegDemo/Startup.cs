using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginRegDemo.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LoginRegDemo {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddDbContext<UserContext> (options => options.UseMySql (Configuration["DBInfo:ConnectionString"]));
            services.AddSession ();
            services.AddMvc ();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            // if (env.IsDevelopment())
            // {
            app.UseDeveloperExceptionPage ();
            // }
            // else
            // {
            //     app.UseExceptionHandler("/Home/Error");
            // }

            app.UseStaticFiles ();
            app.UseSession ();
            app.UseMvc (routes => {
                routes.MapRoute (
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}