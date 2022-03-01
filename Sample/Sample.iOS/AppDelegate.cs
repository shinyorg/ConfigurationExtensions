using Foundation;
using Microsoft.Extensions.Configuration;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;


namespace Sample.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            App.Configuration = new ConfigurationBuilder()
                .AddJsonIosBundle()
                .AddIosUserDefaults()
                .Build();

            Forms.Init();
            this.LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
