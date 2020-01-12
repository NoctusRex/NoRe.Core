using System;
using System.IO;

namespace NoRe.Core
{
    /// <summary>
    /// Base class of all configuration files used by NoRe packages
    /// </summary>
    public abstract class Configuration
    {
        /// <summary>
        /// The path where the file is stored
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Use this constructor to create an object of a derived class
        /// </summary>
        /// <param name="path">The path where the file is stored</param>
        public Configuration(string path) { Path = path; }
        
        /// <summary>
        /// An empty constructor is needed for (de)serialization
        /// </summary>
        public Configuration() { }

        /// <summary>
        /// Reads an xml file into an object derived from Configuration
        /// Throws an exception if Path is not set
        /// Creates the file if it does not exists
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected T Read<T>() where T: Configuration
        {
            if (string.IsNullOrEmpty(Path)) throw new ArgumentException("No path specified");
            if (!File.Exists(Path)) Write();

            return XmlConverter.ConvertXmlToObject<T>(File.ReadAllText(Path));
        }

        /// <summary>
        /// Writes the configuration class into a file
        /// Throws an exception if Path is not set
        /// </summary>
        public void Write()
        {
            if (string.IsNullOrEmpty(Path)) throw new ArgumentException("No path specified");

            File.WriteAllText(Path, XmlConverter.ConvertObjectToXml(this));
        }

        /// <summary>
        /// Must be overriden in order to assign the values of the Read<T> function
        /// </summary>
        public abstract void Read();

    }
}
