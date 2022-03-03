using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System.Windows.Input;


namespace SampleMaui
{
    public class MainViewModel : Shiny.NotifyPropertyChanged
    {
        readonly IChangeToken changeToken;
        bool initialLoad = true;


        public MainViewModel(IConfiguration configuration, IServiceProvider serviceProvider)
        {
            this.changeToken = configuration.GetReloadToken();
            this.changeToken.RegisterChangeCallback(_ => this.Load!.Execute(null), null);

            this.Load = new Command(() =>
            {
                var en = configuration.AsEnumerable().GetEnumerator();
                this.Values.Clear();

                while (en.MoveNext())
                {
                    Console.WriteLine($"{en.Current.Key}: {en.Current.Value}");

                    this.Values.Add(new Item(en.Current.Key, en.Current.Value));
                }

                this.LastLoad = DateTime.Now;
                this.RaisePropertyChanged(nameof(this.LastLoad));
                this.RaisePropertyChanged(nameof(this.Values));
            });

            this.Set = new Command(async () =>
            {
                var page = serviceProvider.GetRequiredService<EntryPage>();
                await App.Current.MainPage.Navigation.PushAsync(page, true);
            });
        }


        public DateTime LastLoad { get; private set; }
        public List<Item> Values { get; } = new List<Item>();
        public ICommand Load { get; }
        public ICommand Set { get; }


        public void OnAppearing()
        {
            if (this.initialLoad)
            {
                this.Load.Execute(null);
                this.initialLoad = false;
            }
        }
    }
}
