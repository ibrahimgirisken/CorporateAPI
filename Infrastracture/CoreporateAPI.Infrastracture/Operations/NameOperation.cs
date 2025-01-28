using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreporateAPI.Infrastructure.Operations
{
    public class NameOperation
    {
        public static string CharacterRegulatory(string name)
                    => name?.ToLowerInvariant()
                        .Replace("\"", "")
                        .Replace("!", "")
                        .Replace("'", "")
                        .Replace("^", "")
                        .Replace("+", "")
                        .Replace("%", "")
                        .Replace("&", "")
                        .Replace("/", "")
                        .Replace("(", "")
                        .Replace(")", "")
                        .Replace("=", "")
                        .Replace("?", "")
                        .Replace("_", "")
                        .Replace(" ", "-")
                        .Replace("@", "")
                        .Replace("€", "")
                        .Replace("¨", "")
                        .Replace("~", "")
                        .Replace(",", "")
                        .Replace(";", "")
                        .Replace(":", "")
                        .Replace(".", "-")
                        .Replace("Ö", "o")
                        .Replace("ö", "o")
                        .Replace("Ü", "u")
                        .Replace("ü", "u")
                        .Replace("ı", "i")
                        .Replace("İ", "i")
                        .Replace("ğ", "g")
                        .Replace("Ğ", "g")
                        .Replace("æ", "")
                        .Replace("ß", "")
                        .Replace("â", "a")
                        .Replace("î", "i")
                        .Replace("ş", "s")
                        .Replace("Ş", "s")
                        .Replace("Ç", "c")
                        .Replace("ç", "c")
                        .Replace("<", "")
                        .Replace(">", "")
                        .Replace("|", "");
        public static void ApplyCharacterRegulationToProperties<T>(IEnumerable<T> items, Func<T, string> propertyGetter, Action<T, string> propertySetter)
        {
            foreach (var item in items)
            {
                var propertyValue = propertyGetter(item);
                if (!string.IsNullOrEmpty(propertyValue))
                {
                    propertySetter(item, CharacterRegulatory(propertyValue));
                }
            }
        }
    }

}
