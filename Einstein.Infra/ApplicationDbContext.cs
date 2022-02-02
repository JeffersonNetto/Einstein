using MongoDB.Driver;

namespace Einstein.Infra
{
    public class ApplicationDbContext
    {
        public static string ConnectionString { get; set; } = default!;
        public static string DatabaseName { get; set; } = default!;
        public static bool IsSSL { get; set; }
        private IMongoDatabase Database { get; }

        public ApplicationDbContext()
        {
            try
            {
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));

                if (IsSSL)
                    settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };

                var mongoClient = new MongoClient(settings);
                Database = mongoClient.GetDatabase(DatabaseName);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar com o servidor.", ex);
            }
        }
    }
}
