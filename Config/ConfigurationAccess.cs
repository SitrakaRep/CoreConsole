using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace CoreConsole.Config
{
    public class ConfigurationAccess
    {
        IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory());
        public IConfigurationRoot BuilderJson
        {
            get
            {
                var builderJson = builder
                    .AddJsonFile("appsettings.json");

                return builderJson.Build();
            }
        }

        public IConfigurationRoot BuilderXml
        {
            get
            {
                var builderXml = builder
                    .AddXmlFile("App.config");

                return builderXml.Build();
            }
        }

        public IConfigurationRoot BuilderUserSecrets
        {
            get
            {
                var builderUserSecrets = builder
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddUserSecrets<Program>()
                    .AddEnvironmentVariables();

                return builderUserSecrets.Build();
            }
        }
    }
}