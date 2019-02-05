using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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
            services.AddSingleton<IGreeter, Greeter> ();
            services.AddMvc();
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
            IApplicationBuilder app, // This object is what allows you to use various types of middleware. 
            IHostingEnvironment env, // This will give information about the environment the app is being run on.
            IGreeter greeter,
            ILogger<Startup> logger) { // Logger is an object that is already registered to core. 
            // This is were all the middleware is registered.
            // This works because asp .net core uses dependency injection 
            // in various places throughout the framework
            // When this method Configure is called .net core will read the args
            // and if the object is known by core then the object or service will be passed in.
            // IConfiguration is an object that is registered to core. Which will allow to instaniate the object.
            // Due to IGreeter not being registered to core the object will not be able to get injected to this method.

            app.Use (next => //This is a function which is a request delegate. 
                {
                    return async context => { // This inner function is invoked once per HTTP request.
                        logger.LogInformation ("Request incoming");
                        if (context.Request.Path.StartsWithSegments ("/mym")) { 
                            await context.Response.WriteAsync ("Hit!!");
                            logger.LogInformation ("Request handled");
                        } else {
                            await next (context); // The outer function will pass the function to the next piece of middleware
                            logger.LogInformation ("Response outgoing");
                        }
                    };
                });
            //A request delegate is something that takes httpContext object and returns a task. 
            //This can be seen in the app.Run method call.

            // app.UseWelcomePage (new WelcomePageOptions {
            //     Path = "/wp" // This will now only respond with the page when the url has the following path extension.
            // });
            //This is a very simple piece of middleware. This will respond with a .net core
            //promo page. Because this method responds to every request. All requests
            //will just return the welcome page. So the below middleware will never have a chance to run.

            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage (); 
            } 
            // else {
            //     app.UseExceptionHandler();
            // }

            app.UseStaticFiles(); 

            app.UseMvc(ConfigureRoutes);
            //app.UseMvcWithDefaultRoute(); //This will use homeController class and index method as the default for all requests. 

            app.Run (async (context) => { //This is a simple piece of middleware.
                var greeting = greeter.MessageOfTheDay ();
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync ($"Not Found");
            });
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            //Here you can define one or more routes for the MVC app.
            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}" ); //This is the route template. 
            // The arg is the name of the route and the second is the template.
        }
    }
}