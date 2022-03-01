namespace Microsoft.Extensions.Configuration
{
    public static partial class ConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddJsonPlatformBundle(this IConfigurationBuilder builder, string fileName = "appsettings.json")
        {
#if XAMARIN_IOS
            builder.AddJsonIosBundle(fileName);
#elif MONOANDROID
            builder.AddJsonAndroidAsset(fileName);
#endif
            return builder;
        }


        public static IConfigurationBuilder AddPlatformPreferences(this IConfigurationBuilder builder)
        {
#if XAMARIN_IOS
            builder.AddIosUserDefaults();
#elif MONOANDROID
            builder.AddAndroidPreferences();
#endif
            return builder;
        }
    }
}
