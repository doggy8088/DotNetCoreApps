using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace DotNetCoreApps
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var host = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
    public class Startup
    {
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddMvc();
        //}

        //public void Configure(IApplicationBuilder app)
        //{
        //    app.UseMvc();
        //}

        public void Configure(IApplicationBuilder app)
        {
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("<p>Pre Processing</p>");

            //    // await next();

            //    await context.Response.WriteAsync("<p>Post Processing</p>");
            //});

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("<p>2nd-tier Processing</p>");

            //    await next();

            //    await context.Response.WriteAsync("<p>2nd-tier Processing</p>");
            //});

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(
                    "Hello World. The Time is: " +
                    DateTime.Now.ToString("hh:mm:ss tt"));

            });
        }
    }

    public class HelloWorldController : Controller
    {
        [Route("api/helloworld")]
        public object HelloWorld()
        {
            return new
            {
                message = "Hello World",
                time = DateTime.Now
            };
        }

        [HttpGet("helloworld")]
        public ActionResult HelloworldMvc()
        {
            ViewBag.Message = "Hello world!";
            ViewBag.Time = DateTime.Now;

            return View("helloworld");
            //return View("~/helloworld.cshtml");
        }
    }
}
