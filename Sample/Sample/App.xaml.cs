using Microsoft.Extensions.Configuration;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]


namespace Sample
{
    public partial class App : Application
    {
        public static IConfiguration Configuration { get; private set; }


        public App()
        {
            Configuration ??= new ConfigurationBuilder()
                .AddJsonPlatformBundle()
                .AddPlatformPreferences()
                .Build();

            this.InitializeComponent();
            this.MainPage = new MainPage();
        }
    }
}
