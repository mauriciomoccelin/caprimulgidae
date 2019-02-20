using Microsoft.Extensions.Configuration;
using System.IO;

namespace Caprimulgidae.Infra.Data.Repositorys
{
    public sealed class AppSettingsHelper
    {
        private AppSettingsHelper() { }

        public static string GetConnectionString(string key = "DefaultConnection") =>
            GetConfiguration().GetConnectionString(key);

        public static IConfigurationRoot GetConfiguration(string jsonFile = "appsettings.json") =>
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(jsonFile)
                .Build();
    }
}
