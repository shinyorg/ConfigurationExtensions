using Android.App;
using Shiny.Extensions.Configuration;


namespace Microsoft.Extensions.Configuration
{
    public static partial class ConfigurationBuilderExtensions
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="fileName"></param>
        /// <param name="optional"></param>
        /// <returns></returns>
        public static IConfigurationBuilder AddJsonAndroidAsset(this IConfigurationBuilder builder, string fileName = "appsettings.json", bool optional = true)
        {
            var assets = Application.Context.Assets;
            var files = assets.List(fileName);
            if (files != null && files.Length == 1)
                builder.AddJsonStream(assets.Open(fileName));

            return builder.AddJsonStream(assets.Open(fileName));
        }


        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IConfigurationBuilder AddAndroidPreferences(this IConfigurationBuilder builder)
            => builder.Add(new SharedPreferencesConfigurationSource());
    }
}
