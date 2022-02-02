using MongoDB.Driver;

namespace Einstein.Api.Configuration
{
    public static class MongoConfig
    {
        public static IServiceCollection AddMongoDbConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IMongoClient>(_ =>
                new MongoClient(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IMongoDatabase>(sp =>
            {
                var client = sp.GetRequiredService<IMongoClient>();
                return client.GetDatabase("einstein");
            });

            return services;
        }
    }
}
