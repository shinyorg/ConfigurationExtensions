using Microsoft.Extensions.Configuration;


namespace Microsoft.Extensions.Configuration
{
    public static partial class ConfigurationBuilderExtensions
    {
        public static ConfigurationBuilder AddAndroidAssetJson(this ConfigurationBuilder builder, string fileName = "appsettings.json", bool required = false)
        {
            return builder;
        }
    }
}
