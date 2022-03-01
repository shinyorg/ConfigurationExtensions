using System.ComponentModel;

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


        //public static T BindTwoWay<T>(this IConfiguration configuration, T obj) where T : INotifyPropertyChanged
        //{
        //    // TODO: sub-binding if deep binding set?
        //    obj.PropertyChanged += (sender, args) =>
        //    {

        //    };
        //    return obj;
        //}
    }
}
