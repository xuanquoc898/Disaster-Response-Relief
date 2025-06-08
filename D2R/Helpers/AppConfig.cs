using Microsoft.Extensions.Configuration;

namespace D2R.Helpers
{
    public static class AppConfig
    {
        public static IConfiguration Configuration { get; }

        static AppConfig()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine($"Base path for config: {basePath}");

            Configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }
    }
}
