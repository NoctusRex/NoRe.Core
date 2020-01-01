using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NoRe.Core
{
    public static class Pathmanager
    {
        public static string StartupDirectory { get { return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); } }
      
        public static string ConfigurationDirectory
        {
            get
            {
                string configPath = Path.Combine(StartupDirectory, "Configuration");
                if (!File.Exists(configPath)) { Directory.CreateDirectory(configPath); }
                return configPath;
            }
        }

    }
}
