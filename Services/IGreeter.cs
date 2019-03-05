using Microsoft.Extensions.Configuration;

namespace HariFood.Services {
    public interface IGreeter //This is the interface definition for the greeting service.
    {
        string MessageOfTheDay ();
    }

    class Greeter : IGreeter // This is the concrete implementation of the IGreeter contract. 
    {
        private IConfiguration _config;

        public Greeter (IConfiguration config) { 
            // Now when core creates an instants of IGreeter it will also need to pass in an IConfiguration object.
            // Thankfully that the core server already has this object registered by default. So we do not need to register it.
            // This will now allow us to pass in the message from the config file.

            _config = config;
        }

        public string MessageOfTheDay () {
            return _config["Greeting"];
        }

    }
}