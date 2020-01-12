using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace NoRe.Core
{
    /// <summary>
    /// Allows conversion from objects into xml strings and vice versa
    /// </summary>
    public static class XmlConverter
    {
        public static string ConvertObjectToXml(object @object)
        {
            XmlSerializer serializer = new XmlSerializer(@object.GetType());
            using (MemoryStream stream = new MemoryStream())
            {

                using (XmlWriter writer = XmlWriter.Create(stream, new XmlWriterSettings()
                {
                    Indent = true,
                    IndentChars = "    ",
                    NewLineHandling = NewLineHandling.Replace,
                    NewLineChars = Environment.NewLine,
                    Encoding = Encoding.UTF8
                }))
                    serializer.Serialize(writer, @object);

                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        public static T ConvertXmlToObject<T>(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
                return (T)serializer.Deserialize(stream);
        }

    }
}
