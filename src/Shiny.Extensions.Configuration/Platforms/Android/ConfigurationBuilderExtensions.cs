using Android.App;


namespace Microsoft.Extensions.Configuration
{
    public static partial class ConfigurationBuilderExtensions
    {
        public static ConfigurationBuilder AddJsonAndroidAsset(this ConfigurationBuilder builder, string fileName = "appsettings.json", bool optional = true)
        {
            var assets = Application.Context.Assets;
            builder.AddJsonStream(assets.Open(fileName));
            return builder;
        }
    }
}
