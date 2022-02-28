using Microsoft.Extensions.Configuration;


namespace Shiny.Extensions.Configuration
{
    public class SharedPreferenceConfigurationProvider : ConfigurationProvider
    {
        public override void Load()
        {
            base.Load();
        }


        public override void Set(string key, string value)
        {
            base.Set(key, value);
        }
    }
}
