using Android.App;
using Android.Content.PM;
using Android.OS;

using Microsoft.Extensions.Configuration;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


namespace Sample.Droid
{
    [Activity(
        Label = "Sample",
        Icon = "@mipmap/icon",
        Theme = "@style/MainTheme",
        MainLauncher = true,
        ConfigurationChanges =
            ConfigChanges.ScreenSize |
            ConfigChanges.Orientation |
            ConfigChanges.UiMode |
            ConfigChanges.ScreenLayout |
            ConfigChanges.SmallestScreenSize
    )]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            App.Configuration = new ConfigurationBuilder()
                .AddJsonAndroidAsset()
                .AddAndroidPreferences()
                .Build();

            Forms.Init(this, savedInstanceState);
            this.LoadApplication(new App());
        }
    }
}