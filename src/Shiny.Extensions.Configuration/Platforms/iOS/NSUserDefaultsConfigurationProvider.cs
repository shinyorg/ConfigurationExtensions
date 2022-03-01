using Foundation;
using Microsoft.Extensions.Configuration;


namespace Shiny.Extensions.Configuration
{
    public class NSUserDefaultsConfigurationProvider : ConfigurationProvider
    {
        public override void Load()
        {
            using (var native = NSUserDefaults.StandardUserDefaults)
            {
                var dict = native.ToDictionary();
                foreach (var pair in dict)
                {
                    var key = pair.Key.ToString();
                    var value = pair.Value.ToString();
                    this.Data.Add(key, value);
                }
                //native.DidChange()
            }
            base.Load();
        }


        public override void Set(string key, string value)
        {
            using (var native = NSUserDefaults.StandardUserDefaults)
            {
                native.SetString(key, value);
                native.Synchronize();
            }
            base.Set(key, value);
        }
    }
}