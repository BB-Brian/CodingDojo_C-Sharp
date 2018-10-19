﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace portfolio_i
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // change from production mode (default) to developer mode
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // We will now add the UseStaticFiles() middleware, which allows our app to access our static files.
            app.UseStaticFiles();
            app.UseMvc();

            // Replace the lines below with the lines above, lines below are present by default
            // app.Run(async (context) =>
            // {
            //     await context.Response.WriteAsync("Hello World!");
            // });

        }

        public Startup(IHostingEnvironment env)
        {
            System.Console.WriteLine(env.ContentRootPath);
            System.Console.WriteLine(env.IsDevelopment());
        }
    }
}
