using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Clrz.ConsoleApp
{
    public class ActionConfiguration
    {
        public string DirectoryPath { get; set; }
        public string Name() => Path.GetFileName(DirectoryPath);
        public string Output() => $"converted_{Name()}";
        public IEnumerable<string> Files() => Directory.GetFiles(DirectoryPath);

        public ActionConfiguration(string directoryPath)
        {
            DirectoryPath = directoryPath;
        }
    }
}