using Microsoft.Extensions.Configuration;


namespace Shiny.Extensions.Configuration
{
    public class PlistConfigurationSource : IConfigurationSource
    {
        public IConfigurationProvider Build(IConfigurationBuilder builder)
            => new PlistConfigurationProvider();
    }
}
