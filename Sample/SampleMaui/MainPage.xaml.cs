namespace SampleMaui
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel viewModel)
        {
            this.InitializeComponent();
            this.BindingContext = viewModel;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            (this.BindingContext as MainViewModel)?.OnAppearing();
        }
    }
}
