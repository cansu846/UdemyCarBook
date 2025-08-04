using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using UdemyCarBook.WebUI.FluentValidation.RegisterValidations;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

builder.Services.AddControllers()
    .AddFluentValidation(config =>
    {
        config.RegisterValidatorsFromAssemblyContaining<RegisterValidator>();
        config.DisableDataAnnotationsValidation = true; // ← BU ÇOK ÖNEMLİ
    });

//UI da jwt configurations
//AddAuthentication(...): Authentication sistemini başlatır.
// Cookie tabanlı bir authentication scheme tanımlar

//API’den alınan JWT token, bir cookie’ye yazılır (örneğin CarBookJwt)
//UI tarafında bu cookie otomatik olarak istekle gönderilir
//Cookie doğrulanarak kullanıcı oturumu yönetilir

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
    {
        opt.LoginPath = "/Login/LoginUser/";
        opt.LogoutPath = "/Logout/LogoutUser";
        opt.AccessDeniedPath = "/Pages/AccessDenied/";
        //Tarayıcı çerez paylaşımını sınırlar (güvenlik amaçlı)
        opt.Cookie.SameSite = SameSiteMode.Strict;
        //	JavaScript tarafından cookie’ye erişilemesin (XSS’e karşı koruma)
        opt.Cookie.HttpOnly = true;
        //HTTPS isteklerde Secure bayrağını ayarlar
        opt.Cookie.SecurePolicy= CookieSecurePolicy.SameAsRequest;
        opt.Cookie.Name = "CarBookJwt";
    });


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();  //bu olmazsa dogrulama calısmaz
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
