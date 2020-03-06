using System.Collections.Generic;
using System.Linq;

namespace Clrz.ConsoleApp
{
    public static class ConfigurationExtensions
    {
        public static AppConfig ToAppConfig(this IEnumerable<string> source)
        {
            return new AppConfig {Actions = source.Select(x => new ActionConfiguration(x))};
        }
    }
}