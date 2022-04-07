// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServerHost.Quickstart.UI;
using Malie.Idp.Data;
using Malie.Idp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
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
            services.AddScoped<ILocalUserService, LocalUserService>(); 

            var currentAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            var builder = services.AddIdentityServer(options =>
            {
                // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
                options.EmitStaticAudienceClaim = true;
            })
            .AddProfileService<LocalUserProfileService>();            
            services.AddDbContext<IdentityDbContext>(b => b.UseSqlServer(connectionString));

            builder.AddConfigurationStore(options => 
                options.ConfigureDbContext = builder => 
                    builder.UseSqlServer(connectionString, options => options.MigrationsAssembly(currentAssembly)));

            builder.AddOperationalStore(options =>
                options.ConfigureDbContext = builder =>
                    builder.UseSqlServer(connectionString, options => options.MigrationsAssembly(currentAssembly)));

            // not recommended for production - you need to store your key material somewhere secure
            // builder.AddDeveloperSigningCredential();
            builder.AddSigningCredential(LoadCertificate());
        }

        private X509Certificate2 LoadCertificate()
        {
            var thumbprint = "29030b53c1576c2af5a78cb6f563c181f0f252ce";

            using var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);
            var certificates = store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, validOnly: true);
            if(certificates.Count == 0)
            {
                throw new Exception("The specified certificate was not found");
            }

            return certificates[0];
        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            InitializeConfigurationData(app);

            // uncomment if you want to add MVC
            app.UseStaticFiles();
            app.UseRouting();

            app.UseIdentityServer();

            // uncomment, if you want to add MVC
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
        }

        private void InitializeConfigurationData(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();

            var persistedGrantContext = scope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>();
            persistedGrantContext.Database.Migrate();

            var context = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
            context.Database.Migrate();

            if(!context.Clients.Any())
            {
                context.Clients.AddRange(Config.Clients.Select(client => client.ToEntity()));
                context.SaveChanges();
            }

            if (!context.IdentityResources.Any())
            {
                context.IdentityResources.AddRange(Config.Ids.Select(id => id.ToEntity()));
                context.SaveChanges();
            }

            if (!context.ApiScopes.Any())
            {
                context.ApiScopes.AddRange(Config.Apis.Select(api => api.ToEntity()));
                context.SaveChanges();
            }

            if (!context.ApiResources.Any())
            {
                context.ApiResources.AddRange(Config.ApiResources.Select(apiResource => apiResource.ToEntity()));
                context.SaveChanges();
            }
        }
    }
}
