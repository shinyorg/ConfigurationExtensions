using Microsoft.Extensions.Configuration;


namespace Shiny.Extensions.Configuration
{
    public class SharedPreferenceConfigurationSource : IConfigurationSource
    {
        public IConfigurationProvider Build(IConfigurationBuilder builder)
            => new SharedPreferenceConfigurationProvider();
    }
}
