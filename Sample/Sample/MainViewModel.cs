using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;


namespace Sample
{
    public class MainViewModel : INotifyPropertyChanged
    {
        readonly IChangeToken changeToken;


        public MainViewModel()
        {
            this.changeToken = App.Configuration.GetReloadToken();
            this.changeToken.RegisterChangeCallback(_ => this.Load.Execute(null), null);

            this.Load = new Command(() =>
            {
                var en = App.Configuration.AsEnumerable().GetEnumerator();
                this.Values.Clear();

                while (en.MoveNext())
                    this.Values.Add((en.Current.Key, en.Current.Value));

                this.LastLoad = DateTime.Now;
                this.OnChange();
            });

            this.Set = new Command(async () =>
            {
                var key = await App.Current.MainPage.DisplayPromptAsync("Configuration Entry", "Please enter your key");
                if (String.IsNullOrWhiteSpace(key))
                    return;

                var value = await App.Current.MainPage.DisplayPromptAsync("Configuration Entry", "Please enter your value"); 
                if (String.IsNullOrWhiteSpace(key))
                    return;

                App.Configuration[key] = value;
            });
        }


        public DateTime LastLoad { get; private set; }
        public List<(string Key, string Value)> Values { get; } = new List<(string Key, string Value)>();
        public ICommand Load { get; }
        public ICommand Set { get; }


        void OnChange([CallerMemberName] string? propertyName = null)
            => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
