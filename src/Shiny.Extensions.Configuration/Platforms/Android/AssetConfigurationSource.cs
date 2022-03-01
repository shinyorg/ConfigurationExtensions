using Microsoft.Extensions.Configuration;


namespace Shiny.Extensions.Configuration
{
    public class AssetConfigurationSource : IConfigurationSource
    {
        public IConfigurationProvider Build(IConfigurationBuilder builder)
            => new AssetConfigurationProvider();
    }
}
