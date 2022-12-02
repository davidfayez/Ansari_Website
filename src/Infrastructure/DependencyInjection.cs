﻿using Ansari_Website.Application.Common.Interfaces;
using Ansari_Website.Infrastructure.Identity;
using Ansari_Website.Infrastructure.Persistence;
using Ansari_Website.Infrastructure.Services;
using ERP.DAL.Domains.Authentication;
using ERP.DAL.Domains;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;

namespace Ansari_Website.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("Ansari_WebsiteDb"));
        }
        else
        {
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        configuration.GetConnectionString("DefaultConnection"),
            //        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddDbContext<ApplicationDbContext>(options =>
                   options.UseSqlServer(
                       configuration.GetConnectionString("DefaultConnection")));
        }

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IDomainEventService, DomainEventService>();

        //services
        //    .AddDefaultIdentity<ApplicationUser>()
        //    .AddRoles<IdentityRole>()
        //    .AddEntityFrameworkStores<ApplicationDbContext>();

        //services.AddIdentityServer()
        //    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();
        services.AddIdentity<AspNetUser, ApplicationRole>() // </-- here you have to replace `IdenityUser` and `IdentityRole` with `ApplicationUser` and `ApplicationRole` respectively
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();

        services.ConfigureApplicationCookie(options =>
        {
            options.ExpireTimeSpan = TimeSpan.FromDays(6);
            options.SlidingExpiration = true;
        });

        //services.AddIdentityServer()
        //    .AddApiAuthorization<AspNetUser, ApplicationDbContext>();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddSession();

        services.AddTransient<IDateTime, DateTimeService>();
        services.AddTransient<IIdentityService, IdentityService>();

        //services.AddAuthentication()
        //    .AddIdentityServerJwt();

        services.AddAuthorization(options => 
            options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator")));

        return services;
    }
}