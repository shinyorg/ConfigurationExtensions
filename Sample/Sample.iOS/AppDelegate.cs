using Foundation;
using Microsoft.Extensions.Configuration;
using UIKit;
using Xamarin.Forms;


namespace Sample.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            App.Configuration = new ConfigurationBuilder()
                .AddJsonIosBundle()
                .Build();

            Forms.Init();
            this.LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
