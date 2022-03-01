using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;


namespace Sample
{
    public class MainViewModel : Shiny.NotifyPropertyChanged
    {
        readonly IChangeToken changeToken;
        bool initialLoad = true;


        public MainViewModel()
        {
            this.changeToken = App.Configuration.GetReloadToken();
            this.changeToken.RegisterChangeCallback(_ => this.Load!.Execute(null), null);

            this.Load = new Command(() =>
            {
                var en = App.Configuration.AsEnumerable().GetEnumerator();
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
                await App.Current.MainPage.Navigation.PushAsync(new EntryPage(), true);
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
