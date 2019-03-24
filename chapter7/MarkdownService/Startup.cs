﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.DocAsCode.MarkdownLite;
using Microsoft.Extensions.DependencyInjection;

namespace MarkdownService {
    public class Startup {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices (IServiceCollection services) {
            services.AddMvc ();

            var builder = new GfmEngineBuilder (new Options ());
            var engine = builder.CreateEngine (new HtmlRenderer ());
            services.AddSingleton<IMarkdownEngine> (engine);

            var configBuilder = new ConfigurationBuilder ();
            configBuilder.AddJsonFile ("config.json", false);
            var configRoot = configBuilder.Build ();
            services.AddSingleton<IConfigurationRoot> (configRoot);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            app.UseMvc ();
        }
    }
}