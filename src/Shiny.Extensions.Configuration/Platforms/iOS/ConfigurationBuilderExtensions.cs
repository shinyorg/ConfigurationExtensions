using Foundation;
using System.IO;


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
        public static ConfigurationBuilder AddJsonIosBundle(this ConfigurationBuilder builder, string fileName = "appsettings.json", bool optional = true)
        {
            var path = Path.Combine(NSBundle.MainBundle.BundlePath, fileName);
            builder.AddJsonFile(path, optional, false);
            return builder;
        }
    }
}