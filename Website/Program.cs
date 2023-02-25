using Ansari_Website.Application;
using Ansari_Website.Application.Common.Interfaces;
using Ansari_Website.Infrastructure;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.Reflection;
using System.Text;
using Website.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//builder.Services.AddAuthentication().AddCookie(config =>
//{
//    config.Cookie.HttpOnly = true;
//    //options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
//    config.Cookie.SameSite = SameSiteMode.Lax;
//    config.Cookie.Name = CookieAuthenticationDefaults.AuthenticationScheme;
//    config.LoginPath = "/Account/Login";
//});

builder.Services.AddMvc();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddSingleton<ICurrentUserService, CurrentUserService>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews().AddFluentValidation(fv =>
{
    fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
    fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {

        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/Account/Index";
    options.AccessDeniedPath = "/Account/Index";
});
builder.Services.AddSession();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new List<CultureInfo>
                    {
                        new CultureInfo("en-US"),
                        new CultureInfo("ar-EG")
                    };
    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});


builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseSession();

app.UseStaticFiles();
var localizationOption = app.Services.GetService<IOptions<RequestLocalizationOptions>>().Value;
app.UseRequestLocalization(localizationOption);
app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

#region Configure Multi Language

//var dateformat = new DateTimeFormatInfo
//{
//    Calendar = new GregorianCalendar(GregorianCalendarTypes.Localized),
//    ShortDatePattern = "dd/MM/yyyy",
//    LongDatePattern = "dd/MM/yyyy"
//};


//IList<CultureInfo> supportedCultures = new List<CultureInfo>
//            {
//                     new CultureInfo("ar"){ DateTimeFormat = dateformat },
//                     new CultureInfo("en-US"){ DateTimeFormat = dateformat },
//            };
//var localizationOptions = new RequestLocalizationOptions
//{
//    //DefaultRequestCulture = new RequestCulture(new CultureInfo("ar") { DateTimeFormat = dateformat }),
//    DefaultRequestCulture = new RequestCulture("en", uiCulture: "en"),
//    SupportedCultures = supportedCultures,
//    SupportedUICultures = supportedCultures
//};
//// Find the cookie provider with LINQ
//var cookieProvider = localizationOptions.RequestCultureProviders
//    .OfType<CookieRequestCultureProvider>()
//    .First();
//// Set the new cookie name
//cookieProvider.CookieName = "AnsariERPLang";
//app.UseRequestLocalization(localizationOptions);

#endregion

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});
app.Run();
