using Einstein.Api.Extensions;
using Einstein.Core.Helpers;
using Einstein.Core.Services;
using System.Reflection;

namespace Einstein.Api.IoC
{
    public static class InjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {            
            services.AddScoped<INotificador, Notificador>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            services.AddMemoryCache();

            services.Scan(s => s.FromAssemblies(Assembly.Load("Einstein.Infra"))
                                .AddClasses(c => c.Where(x => !x.IsAbstract && x.IsClass && x.IsPublic).InNamespaces("Einstein.Infra.Repositories"))
                                .AsMatchingInterface()
                                .WithScopedLifetime()
                                .FromAssemblies(Assembly.Load("Einstein.Infra"))
                                .AddClasses(c => c.Where(x => !x.IsAbstract && x.IsClass && x.IsPublic).InNamespaces("Einstein.Infra.QueryServices"))
                                .AsMatchingInterface()
                                .WithScopedLifetime()
                                .FromAssemblies(Assembly.Load("Einstein.Core"))
                                .AddClasses(c => c.Where(x => !x.IsAbstract && x.IsClass && x.IsPublic).InNamespaces("Einstein.Core.Services"))
                                .AsSelf()
                                .WithScopedLifetime());
        }
    }
}
