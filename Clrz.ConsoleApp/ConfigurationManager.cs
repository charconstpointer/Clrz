using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Clrz.ConsoleApp.Interface;

namespace Clrz.ConsoleApp
{
    internal class ConfigurationManager : IConfigurationManager
    {
        private readonly IEnumerable<string> _allowedFolders = new[] {"noise","color","resolution"};

        public async Task<AppConfig> GetConfiguration()
        {
            var currentDirectoryFolders = Directory.GetDirectories(Directory.GetCurrentDirectory());
            var allowedDirectories = currentDirectoryFolders.Where(x => _allowedFolders.Contains(Path.GetFileName(x)));
            return await Task.FromResult(allowedDirectories.ToAppConfig());
        }
    }
}