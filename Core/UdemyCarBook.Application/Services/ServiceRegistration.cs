using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Services
{
    public static class ServiceRegistration
    {
        public static void AddApplicationService(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(typeof
                (ServiceRegistration).Assembly));
        }
    }
}
//IServiceCollection services: ASP.NET Core'un servis koleksiyonudur. Tüm bağımlılıklar buraya eklenir.

//this IServiceCollection ifadesi sayesinde bu metod bir extension method olur. Böylece builder.Services.AddApplicationService(...) şeklinde çağrılabilir.

//IConfiguration configuration: Genelde appsettings.json gibi yapılandırma verilerine erişmek için alınır.

//| Parça | Açıklama |
//| --------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------- |
//| `AddMediatR(...)`                       | MediatR servisini servis koleksiyonuna ekler. Böylece Controller'larda MediatR kullanılabilir.                                                 |
//| `cfg.RegisterServicesFromAssembly(...)` | Bu yöntem, belirli bir assembly'deki tüm **IRequestHandler**, **IRequest** ve benzeri MediatR bileşenlerini otomatik olarak tarar ve kaydeder. |
//| `typeof(ServiceRegistration).Assembly`  | Yani bu satır, *bu sınıfın bulunduğu proje/katmandaki tüm MediatR handler'larını* bulur ve kaydeder.                                           |
