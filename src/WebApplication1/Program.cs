using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var contentRoot = Directory.GetCurrentDirectory();
            var webRoot = Path.Combine(contentRoot, "wwwroot");

            // http://stackoverflow.com/questions/36635003/how-do-we-set-contentrootpath-and-webrootpath
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(contentRoot)
                .UseWebRoot(webRoot)
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
