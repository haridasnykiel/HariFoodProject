using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HariFood {
    public class Startup {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices (IServiceCollection services) 
        // This is the method that allows the user to register
        // services. So in order for core to known about the new
        // object the object needs to be registered here.
        {
            //services.AddSingleton (); // Will tell core that the object will only need to be instantiated onces.
            //services.AddTransient(); // Will tell core that every time this type is required create a new instants.
            //services.AddScoped(); // Will tell core that the type is only instaniate once for every http request.
            services.AddSingleton<IGreeter, Greeter>(); 
            // The above says that when ever anyone needs service that implements IGreeter. Create an instants of Greeter
            // pass that object. So the first param is the service and the second is the implementation of that service.
            // This is a method of dependancy injection that core takes. By passing the whole type as a parameter.
            // Here are some advantages: 
            // - The software becomes more extensable, flexible and testable.
            // - Because you are no longer tied to specific implementation of that service (interface).
            // - now you can comfigure different greeting objects to be used at runtime just by changing this method.
            // - Also inside a unit test you can invoke the configure method and pass any greeter type that you want. 
            // Instead of having to work around any greeter that was instantiated in the method.

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (
            IApplicationBuilder app,
            IHostingEnvironment env,
            IGreeter greeter) { 
            // This works because asp .net core uses dependency injection 
            // in various places throughout the framework
            // When this method Configure is called .net core will read the args
            // and if the object is known by core then the object or service will be passed in.
            // IConfiguration is an object that is registered to core. Which will allow to instaniate the object.
            // Due to IGreeter not being registered to core the object will not be able to get injected to this method.
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            app.Run (async (context) => {
                var greeting = greeter.MessageOfTheDay ();
                await context.Response.WriteAsync (greeting);
                // the above line will respond to every type of request with the same text.
            });
        }
    }
}