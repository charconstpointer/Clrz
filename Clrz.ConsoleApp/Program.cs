using System;
using System.Threading.Tasks;

namespace Clrz.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var configurationManager = new ConfigurationManager();
            var config = await configurationManager.GetConfiguration();
            foreach (var configAction in config.Actions)
            {
                Console.WriteLine(configAction.DirectoryPath);
                Console.WriteLine(configAction.Name());
            }
        }
    }
}