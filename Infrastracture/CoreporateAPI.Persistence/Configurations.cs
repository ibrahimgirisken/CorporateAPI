using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreporateAPI.Persistence
{
    static class Configurations
    {
        public static string ConnectionString
        {
            get
            {
                string basePath = Directory.GetCurrentDirectory();
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(basePath);
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("MsSql");
            }
        }


    }
}
