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
            this.Values = new List<Item>();
            this.changeToken = App.Configuration.GetReloadToken();
            this.changeToken.RegisterChangeCallback(
                _ =>
                {
                    this.LastLoad = DateTime.Now;
                    this.Load!.Execute(null);
                }, 
                null
            );

            this.Load = new Command(() =>
            {
                this.IsBusy = true;
                var en = App.Configuration.AsEnumerable().GetEnumerator();
                var list = new List<Item>();

                while (en.MoveNext())
                    list.Add(new Item(en.Current.Key, en.Current.Value));
                
                this.Values = list;
                this.IsBusy = false;
            });

            this.Set = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new EntryPage(), true);
            });
        }


        bool busy;
        public bool IsBusy
        {
            get => this.busy;
            set => this.Set(ref this.busy, value);
        }

        
        DateTime lastLoad;
        public DateTime LastLoad 
        {
            get => this.lastLoad;
            private set => this.Set(ref this.lastLoad, value);
        }



        List<Item> values;
        public List<Item> Values 
        { 
            get => this.values;
            set
            {
                this.values = value;
                this.RaisePropertyChanged();
            }
        }


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
