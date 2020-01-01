using System;
using System.IO;
using System.Xml.Serialization;

namespace NoRe.Core
{
    public abstract class Configuration
    {
        public string Path { get; set; }

        public Configuration(string path) { Path = path; }
        public Configuration() { }

        protected T Read<T>() where T: Configuration
        {
            if (string.IsNullOrEmpty(Path)) throw new ArgumentException("No path specified");
            if (!File.Exists(Path)) Write();

            return XmlConverter.ConvertXmlToObject<T>(File.ReadAllText(Path));
        }

        public void Write()
        {
            if (string.IsNullOrEmpty(Path)) throw new ArgumentException("No path specified");

            File.WriteAllText(Path, XmlConverter.ConvertObjectToXml(this));
        }

        public abstract void Read();

    }
}
