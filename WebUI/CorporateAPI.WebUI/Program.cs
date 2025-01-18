using CorporateAPI.WebUI.Services.Abstract;
using CorporateAPI.WebUI.Services.Concrete;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(10);
    options.Limits.RequestHeadersTimeout = TimeSpan.FromSeconds(30);
});
builder.Services.AddHttpClient("Admin", (options) =>
{
    options.BaseAddress = new Uri("https://localhost:7272/api/");
});

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IDetectionService, DetectionService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();




var supportedCultures = new[] { "en", "tr", "de" };
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en"),
    SupportedCultures = supportedCultures.Select(c => new CultureInfo(c)).ToList(),
    SupportedUICultures = supportedCultures.Select(c => new CultureInfo(c)).ToList()
};





var app = builder.Build();




app.UseRequestLocalization(localizationOptions);


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.Use(async (context, next) =>
{
    var language = context.Request.RouteValues["language"]?.ToString();

    if (!string.IsNullOrEmpty(language))
    {
        try
        {
            var culture = new CultureInfo(language);
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;
        }
        catch (CultureNotFoundException)
        {
            // Desteklenmeyen dil durumunda varsayýlan dil ayarlanabilir
            var defaultCulture = new CultureInfo("en");
            CultureInfo.CurrentCulture = defaultCulture;
            CultureInfo.CurrentUICulture = defaultCulture;
        }
    }

    await next.Invoke();
});



app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{language=en}/{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
