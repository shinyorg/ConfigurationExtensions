using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;
using System.Windows.Input;


namespace SampleMaui
{
    public class EntryViewModel : Shiny.NotifyPropertyChanged
    {
        readonly IConfiguration configuration;


        public EntryViewModel(IConfiguration configuration)
        {
            this.configuration = configuration;

            this.Enter = new Command(async () =>
            {
                try
                {
                    configuration[this.Key.Trim()] = this.Value.Trim();
                    await App.Current.MainPage.Navigation.PopAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    await App.Current.MainPage.DisplayAlert("ERROR", ex.ToString(), "OK");
                }
            });
        }


        protected override void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            base.RaisePropertyChanged(propertyName);
            if (propertyName == nameof(Key))
            {
                this.ActionText = String.IsNullOrWhiteSpace(this.Key) || this.configuration[this.Key] == null
                    ? "Add"
                    : "Update";
            }
            this.Enter.CanExecute(
                !String.IsNullOrWhiteSpace(this.Key) &&
                !String.IsNullOrWhiteSpace(this.Value)
            );
        }


        public ICommand Enter { get; }


        string key;
        public string Key
        {
            get => this.key;
            set => this.Set(ref this.key, value);
        }


        string value;
        public string Value
        {
            get => this.value;
            set => this.Set(ref this.value, value);
        }


        string actionText = "Add To Configuration";
        public string ActionText
        {
            get => this.actionText;
            set => this.Set(ref this.actionText, value);
        }
    }
}
