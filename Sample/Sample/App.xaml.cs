using Microsoft.Extensions.Configuration;
using Xamarin.Forms;


namespace Sample
{
    public partial class App : Application
    {
        public static IConfiguration Configuration { get; set; }


        public App()
        {
            this.InitializeComponent();
            this.MainPage = new MainPage();
        }
    }
}
