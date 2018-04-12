using Microsoft.Extensions.Configuration;

namespace OdeToFood
{
    public class Greeter : IGreeter
    {
        private readonly IConfiguration configuration;

        public Greeter(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        
        public string GetMessageOfTheDay()
        {
            return configuration["Greeting"];
        }
    }
}