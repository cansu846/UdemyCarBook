using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Text;
using UdemyCarBook.Application.Feature.CQRS.Handlers.AboutHandlers;
using UdemyCarBook.Application.Feature.CQRS.Handlers.BannerHandlers;
using UdemyCarBook.Application.Feature.CQRS.Handlers.BrandHandler;
using UdemyCarBook.Application.Feature.CQRS.Handlers.CarHandler;
using UdemyCarBook.Application.Feature.CQRS.Handlers.CarHandlers;
using UdemyCarBook.Application.Feature.CQRS.Handlers.CategoryForBlogHandlers;
using UdemyCarBook.Application.Feature.CQRS.Handlers.ContactHandlers;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.AppUserInterfaces;
using UdemyCarBook.Application.Interfaces.BlogInterfaces;
using UdemyCarBook.Application.Interfaces.CarFeatureInterfaces;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Application.Interfaces.CommentInterfaces;
using UdemyCarBook.Application.Interfaces.RentACarInterfaces;
using UdemyCarBook.Application.Interfaces.StatisticsInterfaces;
using UdemyCarBook.Application.Interfaces.TagCloudInterfaces;
using UdemyCarBook.Application.Services;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;
using UdemyCarBook.Persistence.Repositories;
using UdemyCarBook.Persistence.Repositories.AppUserRepositories;
using UdemyCarBook.Persistence.Repositories.BlogRepositories;
using UdemyCarBook.Persistence.Repositories.CarFeatureRepositories;
using UdemyCarBook.Persistence.Repositories.CarRepositories;
using UdemyCarBook.Persistence.Repositories.CommentRepositories;
using UdemyCarBook.Persistence.Repositories.RentACarRepositories;
using UdemyCarBook.Persistence.Repositories.StatisticsRepositories;
using UdemyCarBook.Persistence.Repositories.TagCloudRepository;
using UdemyCarBook.WebUI.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IRepository<Comment>, CommentRepository>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IStatisticsRepository, StatisticsRepository>();
builder.Services.AddScoped<IRentACarRepository, RentACarRepository>();
builder.Services.AddScoped<ICarPricingRepository, CarPricingRepository>();
builder.Services.AddScoped<ICarFeatureRepository, CarFeatureRepository>();
builder.Services.AddScoped<IAppUserRepository, AppUserRepository>();

builder.Services.AddScoped<CarBookContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();
builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();

builder.Services.AddScoped<CreateBrandCommandHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();
builder.Services.AddScoped<RemoveBrandCommandHandler>();
builder.Services.AddScoped<GetBrandQueryHandler>();
builder.Services.AddScoped<GetBrandByIdQueryHandler>();

builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();
builder.Services.AddScoped<RemoveBannerCommandHandler>();
builder.Services.AddScoped<GetBannerQueryHandler>();
builder.Services.AddScoped<GetBannerByIdQueryHandler>();

builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<RemoveCarCommandHandler>();
builder.Services.AddScoped<GetCarQueryHandler>();
builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<GetCarWithBrandQueryHandler>();

builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<ICarPricingRepository, CarPricingRepository>();
builder.Services.AddScoped<ITagCloudRepository, TagCloudRepository>();
builder.Services.AddScoped<IRepository<Comment>, CommentRepository>();


builder.Services.AddScoped<CreateCategoryForBlogCommandHandler>();
builder.Services.AddScoped<UpdateCategoryForBlogCommandHandler>();
builder.Services.AddScoped<RemoveCategoryForBlogCommandHandler>();
builder.Services.AddScoped<GetCategoryForBlogQueryHandler>();
builder.Services.AddScoped<GetCategoryForBlogByIdQueryHandler>();

builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();
builder.Services.AddScoped<RemoveContactCommandHandler>();
builder.Services.AddScoped<GetContactQueryHandler>();
builder.Services.AddScoped<GetContactByIdQueryHandler>();

//mediatr register edilmesi
builder.Services.AddApplicationService(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//CORS, farklı domain'den gelen isteklerin kabul edilip edilmeyeceğini belirler.
//UI ile API farklı portlarda/domaine sahipse bu gereklidir
//CORS ayarı yapılmazsa istekler engellenir.
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        //API'ye gelen isteklerdeki tüm HTTP header'larına izin verir.
        //Örn: Authorization, Content - Type, X - Custom - Header gibi.
        builder.AllowAnyHeader()
    //GET, POST, PUT, DELETE gibi tüm HTTP metodlarına izin verir.
    .AllowAnyMethod()
    // Her kaynaktan gelen isteğe izin ver demektir (wildcard).
    // Yani: http://localhost:4200, http://myfrontend.com, http://evil.co
    .SetIsOriginAllowed((host) => true)
    //        Tarayıcıdan gelen "cookie", "authorization" header'ları gibi kimlik doğrulama bilgilerine izin verir.
    //         Bu olmadan Authorization: Bearer... gibi header'lar CORS tarafından engellenir.
    //      ⚠️ AllowCredentials() kullandığında AllowAnyOrigin() kullanamazsın!
    //      Bu yüzden SetIsOriginAllowed(...) kullanılıyor.
    .AllowCredentials();
    });
});

builder.Services.AddSignalR();

//configurationdsan jwt ayarlarını alır
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"];

//Jwt authentication servisini register et
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            //kim tarafından oluşturulduğu kontrol edilir.
            ValidateIssuer = true,
            ValidIssuer = jwtSettings["Issuer"],

            ValidateAudience = true,
            //kim için oluşturulduğu kontrol edilir.
            ValidAudience = jwtSettings["Audience"],

            //	Token’ın süresi bitmiş mi diye kontrol eder.
            ValidateLifetime = true, // token süresi kontrolü

            ValidateIssuerSigningKey = true,
            //Token’ı imzalamak/doğrulamak için kullanılan gizli anahtar
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!)),

            //	Token süresiyle ilgili zaman toleransı. Default: 5 dakika. Genellikle TimeSpan.Zero yapılır.
            ClockSkew = TimeSpan.Zero // Token süresi bittiğinde hemen geçersiz olsun
        };
    });

//Yetkilendirme servisi ekle
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseCors("CorsPolicy");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();  // <- JWT burada devreye girer

app.UseAuthorization();

app.MapControllers();
//signalr için kısaca url oluşturur
app.MapHub<CarHub>("/CarHub");
app.Run();
