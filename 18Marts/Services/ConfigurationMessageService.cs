using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _18Marts.Services
{
    public class ConfigurationMessageService : IMessageService
    {
        private IConfiguration configuration;

        public ConfigurationMessageService(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public string GetMessage()
        {
            return configuration["Message"];
        }
    }
}