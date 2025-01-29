using CorporateAPI.WebUI.Abstract;
using CorporateAPI.WebUI.Concrete;
using CorporateAPI.WebUI.ViewComponents;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// HttpClient tanýmý
builder.Services.AddHttpClient("Admin", (options) =>
{
    options.BaseAddress = new Uri("https://localhost:7272/api/");
});

// Gerekli servisler
builder.Services.AddScoped(typeof(ApiDataComponent<>));
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IFileService, FileService>();

// Desteklenen diller ve varsayýlan kültür
var supportedCultures = new[] { "en", "tr", "de" };
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("tr"),
    SupportedCultures = supportedCultures.Select(c => new CultureInfo(c)).ToList(),
    SupportedUICultures = supportedCultures.Select(c => new CultureInfo(c)).ToList()
};

var app = builder.Build();

// Localization Middleware
app.UseRequestLocalization(localizationOptions);

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Route üzerinden dil ayarý middleware
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
            var defaultCulture = new CultureInfo("en");
            CultureInfo.CurrentCulture = defaultCulture;
            CultureInfo.CurrentUICulture = defaultCulture;
        }
    }

    await next.Invoke();
});

app.UseAuthorization();

//Route tanýmlarý
app.MapControllerRoute(
    name: "page",
    pattern: "{language=en}/{urlAddress}",
    defaults: new { controller = "Page", action = "GetByLanguageAndUrl" }
);

app.MapControllerRoute(
    name: "default",
    pattern: "{language=en}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "withoutAction",
    pattern: "{language=en}/{controller}",
    defaults: new { action = "Index" });

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.Run();
