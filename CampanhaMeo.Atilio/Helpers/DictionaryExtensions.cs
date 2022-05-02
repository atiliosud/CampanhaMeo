using System.Collections.Generic;

namespace CampanhaMeo.Atilio.Helpers
{
    public static class DictionaryExtensions
    {
        public static KeyValuePair<string, string> New(string keyAndValue)
        {
            return new KeyValuePair<string, string>(keyAndValue, keyAndValue);
        }
        public static KeyValuePair<string, string> New(string key, object value)
        {
            return new KeyValuePair<string, string>(key, value.ToString()!);
        }
    }
}