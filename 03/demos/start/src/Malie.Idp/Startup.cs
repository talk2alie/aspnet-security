// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServerHost.Quickstart.UI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace Malie.Idp
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }

        public Startup(IWebHostEnvironment environment)
        {
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Put in appsetting.json file
            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=IdentityServer;Trusted_Connection=True;";

            // uncomment, if you want to add an MVC-based UI
            services.AddControllersWithViews();

            var currentAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            var builder = services.AddIdentityServer(options =>
            {
                // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
                options.EmitStaticAudienceClaim = true;
            })            
            .AddTestUsers(TestUsers.Users);

            builder.AddConfigurationStore(options => 
                options.ConfigureDbContext = builder => 
                    builder.UseSqlServer(connectionString, options => options.MigrationsAssembly(currentAssembly)));

            // not recommended for production - you need to store your key material somewhere secure
            // builder.AddDeveloperSigningCredential();
            builder.AddSigningCredential(LoadCertificate());
        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // uncomment if you want to add MVC
            app.UseStaticFiles();
            app.UseRouting();

            app.UseIdentityServer();

            // uncomment, if you want to add MVC
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
        }

        private X509Certificate2 LoadCertificate()
        {
            var thumbprint = "af2b0d8045aa098e851eb5d08600a6bd2f6c0761";

            using var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);
            var certificates = store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, validOnly: true);
            if(certificates.Count == 0)
            {
                throw new Exception("The specified certificate was not found");
            }

            return certificates[0];
        }
    }
}
