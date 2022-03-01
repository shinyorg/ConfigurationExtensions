using Android.App;
using AndroidX.Preference;
using Microsoft.Extensions.Configuration;


namespace Shiny.Extensions.Configuration
{
    public class SharedPreferencesConfigurationProvider : ConfigurationProvider
    {
        bool loaded = false;


        public override void Load()
        {
            //.RegisterOnSharedPreferenceChangeListener;
            using (var prefs = PreferenceManager.GetDefaultSharedPreferences(Application.Context))
            {
                if (prefs?.All != null)
                { 
                    foreach (var pair in prefs.All)
                    {
                        this.Data.Add(pair.Key, pair.Value.ToString());
                    }
                }
                if (!this.loaded)
                {
                    //prefs.RegisterOnSharedPreferenceChangeListener()
                    this.loaded = true;
                }
            }
            base.Load();
        }


        public override void Set(string key, string value)
        {
            using (var prefs = PreferenceManager.GetDefaultSharedPreferences(Application.Context))
            {
                using (var editor = prefs.Edit()!)
                {
                    editor.PutString(key, value);
                    editor.Apply();
                }
            }
            base.Set(key, value);
        }
    }
}