using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ServicesWebApp.Helpers
{
    public class AppSettings
    {
        #region Properties

        public string Bitacora { get; set; }
        public string RutaArchivo { get; set; }
        public string Url { get; set; }
        public string PhysicalServerFiles { get; set; }
        public string PhysicalServerFolder { get; set; }
        public IConfiguration Configuration { get; set; }

        #endregion

        #region Methods

        public AppSettings()
        {
            var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var filename = $"appsettings.{envName}.json";
            filename = filename.Replace("..", ".");
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                 .AddJsonFile(filename, optional: false)
                 .Build();

            this.Bitacora = configuration.GetValue<string>("AppSettings:Bitacora");
            this.RutaArchivo = configuration.GetValue<string>("AppSettings:RutaArchivo");
            this.Url = configuration.GetValue<string>("AppSettings:Url");
            this.PhysicalServerFiles = configuration.GetValue<string>("AppSettings:PhysicalServerFiles");
            this.PhysicalServerFolder = configuration.GetValue<string>("AppSettings:PhysicalServerFolder");
            this.Configuration = configuration.GetSection("AppSettings");
            
        }

        #endregion
    }
}
