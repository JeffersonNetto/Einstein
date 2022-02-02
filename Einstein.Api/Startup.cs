using Einstein.Api.Configuration;
using Einstein.Api.IoC;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Einstein.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();

            services.AddMongoDbConfiguration(Configuration);

            services.AddJwtConfiguration(Configuration);

            services.WebApiConfiguration(Configuration);

            services.Configure<ApiBehaviorOptions>(_ => _.SuppressModelStateInvalidFilter = true);

            services.RegisterServices();

            services.ConfigureApplicationCookie(options =>
            {
                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.Headers["Location"] = context.RedirectUri;
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                };
            });

            services.AddSwaggerConfiguration();
        }

        public void Configure(WebApplication app)
        {
            app.UseMvcConfiguration();
        }
    }
}
