using Xamarin.Forms;


namespace Sample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            //this.BindingContext = new MainViewModel();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            (this.BindingContext as MainViewModel)?.OnAppearing();
        }
    }
}
