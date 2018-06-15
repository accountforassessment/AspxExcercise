using System.IO;
using System.Xml.Serialization;

namespace AspxExample.Utilities
{
    /// <summary>
    /// Summary description for XMLParserUtility
    /// </summary>
    public static class XMLParserUtility
    {
        public static T Deserialize<T>(string xmlString, string rootNode)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(rootNode));
            using (StringReader reader = new StringReader(xmlString))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}