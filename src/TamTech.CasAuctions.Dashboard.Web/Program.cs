using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;  
using Microsoft.AspNetCore;      

namespace TamTech.CasAuctions.Dashboard.Web
{
    public class Program
    {

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
             WebHost.CreateDefaultBuilder(args)
              //    .UseApplicationInsights() 
                 .UseKestrel(c => c.AddServerHeader = false)
                 .UseIISIntegration()
                 .UseStartup<Startup>();


    }
}
