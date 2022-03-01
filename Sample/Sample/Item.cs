using System;


namespace Sample
{
    public class Item
    {
        public Item(string key, string value)
        {
            Key = key ?? throw new ArgumentNullException(nameof(key));
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }


        public string Key { get; }
        public string Value { get; }
    }
}
