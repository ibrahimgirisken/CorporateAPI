using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreporateAPI.Persistence
{
    static class Configuration
    {
        static public string ConnectionString
        {
            get
            {
                ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

                // 1. Uygulamanın o an çalıştığı fiziksel klasörü al
                string path = Directory.GetCurrentDirectory();

                // 2. appsettings.json dosyasını ara
                if (!File.Exists(Path.Combine(path, "appsettings.json")))
                {
                    // Eğer dosya burada yoksa (Development ortamındaysan), API projesinin içine bak
                    path = Path.Combine(path, "../../../CorporateAPI/Presentation/CoreporateAPI.API");
                }

                configurationBuilder.SetBasePath(path);
                configurationBuilder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                IConfigurationRoot configuration = configurationBuilder.Build();
                return configuration.GetConnectionString("MySql");

            }
        }
    }
}
