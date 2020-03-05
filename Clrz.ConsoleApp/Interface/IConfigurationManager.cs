using System;
using System.Collections;
using System.Threading.Tasks;

namespace Clrz.ConsoleApp.Interface
{
    public interface IConfigurationManager
    {
        Task<AppConfig> GetConfiguration();
    }
}