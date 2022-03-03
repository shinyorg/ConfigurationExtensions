namespace SampleMaui
{
    public partial class App : Application
    {
        public App(MainPage mainPage)
        {
            InitializeComponent();
            this.MainPage = new NavigationPage(mainPage);
        }
    }
}