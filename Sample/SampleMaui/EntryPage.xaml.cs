namespace SampleMaui
{
    public partial class EntryPage : ContentPage
    {
        public EntryPage(EntryViewModel viewModel)
        {
            this.InitializeComponent();
            this.BindingContext = viewModel;
        }
    }
}