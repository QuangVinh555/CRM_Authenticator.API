using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Configurations
{
    public class ConfigManager
    {
        private readonly IConfiguration _configuration;

        public ConfigManager()
        {
            this._configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();
        }
        public string ExpiredToken
        {
            get
            {
                return this._configuration["JwtSettings:ExpiredToken"];
            }
        }
    }
}
