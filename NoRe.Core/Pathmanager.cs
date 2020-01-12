using System.IO;
using System.Reflection;

namespace NoRe.Core
{
    /// <summary>
    /// Contains paths used by NoRe Packages
    /// </summary>
    public static class Pathmanager
    {
        public static string StartupDirectory { get { return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); } }
      
        /// <summary>
        /// Creats the directory if it does not exist
        /// </summary>
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
