using System.Globalization;
using System.Reflection;
using Ansari_Website.Application;
using Ansari_Website.Application.Common.Interfaces;
using Ansari_Website.Infrastructure;
using Ansari_Website.Infrastructure.Persistence;
using Ansari_Website.WebUI.Filters;
using Ansari_Website.WebUI.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using NSwag;
using NSwag.Generation.Processors.Security;

namespace Ansari_Website.WebUI;

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
        services.AddAuthentication().AddCookie(config =>
        {
            config.Cookie.HttpOnly = true;
            //options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            config.Cookie.SameSite = SameSiteMode.Lax;
            config.Cookie.Name = CookieAuthenticationDefaults.AuthenticationScheme;
            config.LoginPath = "/Account/Login";
        });
        services.AddMvc();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddInfrastructure(Configuration);
        services.AddApplication();

        //services.AddMiniProfiler(options =>
        //{
        //    options.PopupRenderPosition = StackExchange.Profiling.RenderPosition.BottomLeft;
        //    options.PopupShowTimeWithChildren = true;
        //});

        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddSingleton<ICurrentUserService, CurrentUserService>();

        services.AddHttpContextAccessor();

        services.AddControllersWithViews().AddFluentValidation(fv =>
        {
            fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
            fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        });
        services.AddRazorPages();

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        //app.UseMiniProfiler();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        #region Configure Multi Language

        var dateformat = new DateTimeFormatInfo
        {
            Calendar = new GregorianCalendar(GregorianCalendarTypes.Localized),
            ShortDatePattern = "dd/MM/yyyy",
            LongDatePattern = "dd/MM/yyyy"
        };


        IList<CultureInfo> supportedCultures = new List<CultureInfo>
            {
                     new CultureInfo("ar"){ DateTimeFormat = dateformat },
                     new CultureInfo("en-US"){ DateTimeFormat = dateformat },
            };
        var localizationOptions = new RequestLocalizationOptions
        {
            //DefaultRequestCulture = new RequestCulture(new CultureInfo("ar") { DateTimeFormat = dateformat }),
            DefaultRequestCulture = new RequestCulture("en", uiCulture: "en"),
            SupportedCultures = supportedCultures,
            SupportedUICultures = supportedCultures
        };
        // Find the cookie provider with LINQ
        var cookieProvider = localizationOptions.RequestCultureProviders
            .OfType<CookieRequestCultureProvider>()
            .First();
        // Set the new cookie name
        cookieProvider.CookieName = "AnsariERPLang";
        app.UseRequestLocalization(localizationOptions);

        #endregion

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=CPanelLookups}/{action=AboutUs}/{id?}");
            endpoints.MapRazorPages();
        });

    }
}
