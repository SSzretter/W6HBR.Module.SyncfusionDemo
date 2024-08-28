using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Oqtane.Infrastructure;
using Syncfusion.Blazor;


namespace W6HBR.Module.SyncfusionDemo.Server.Startup
{
    public class ServerStartup : IServerStartup
    {
        public IConfigurationRoot Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSyncfusionBlazor();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();

			/*
				This method of license storage requires adding an entry to your appsettings.json file.
				e.g. add this:  "SyncfusionLicense": "Your license code here",
				Alternatively, you can directly put your license code in the SyncfusionLicense variable below.
				var SyncfusionLicense = "Your license code here";
			*/
			
            var SyncfusionLicense = Configuration.GetSection("SyncfusionLicense");
            if (SyncfusionLicense != null)
            {
                //Register the Syncfusion license
                Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(SyncfusionLicense.Value);
            }
        }
        public void ConfigureMvc(IMvcBuilder mvcBuilder)
        {
        }
    }

    /*
    internal class ServerStartup
    {
    }
    */
}
