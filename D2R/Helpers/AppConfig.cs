using Microsoft.Extensions.Configuration;
using System.IO;

namespace D2R.Helpers
{
    public static class AppConfig
    {
        public static IConfiguration Configuration { get; }

        static AppConfig()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) 
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }
    }
}
