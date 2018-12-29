using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace HariFood
{
    public class Program
    {
        public static void Main(string[] args) // This will take command line args. This is the entry point for the program.
        {
            CreateWebHostBuilder(args).Build().Run(); // This will build a web host. Passing any args from the command line.
            //And tell the web host/server to build and start to run.
            // This builds its own web server. This is done by using microsoft hosting namespace. 
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args) // This makes it easy to spin up a web server. 
            //(create default builder creates the web server).
                .UseStartup<Startup>(); //This is to configure how the application should behave.
                //The above method will return a IWebhostBuilder object. Which can then be built and run.
    }
}
