using System.IO;

namespace Clrz.ConsoleApp
{
    public class ActionConfiguration
    {
        public string DirectoryPath { get; set; }
        public string Name() => Path.GetFileName(DirectoryPath);
    }
}