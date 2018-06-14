using Newtonsoft.Json;
using System.IO;
using System.Xml.Serialization;

namespace RestClient
{
    /// <summary>
    /// An helper class for serializitaion of several types.
    /// </summary>
    public static class Serializer
    {
        /// <summary>
        /// Deserializes json to POCO.
        /// </summary>
        /// <typeparam name="T">Type of POCO.</typeparam>
        /// <param name="json">Json that should be deserialized.</param>
        /// <returns>Returns the deserialized.</returns>
        public static T DeserializeJson<T>(string json) where T : new()
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// Deserializes xml to POCO.
        /// </summary>
        /// <typeparam name="T">Type of POCO.</typeparam>
        /// <param name="xml">Xml that should be deserialized.</param>
        /// <returns>Returns the deserialized.</returns>
        public static T DeserializeXml<T>(string xml) where T : new()
        {
            var serializer = new XmlSerializer(typeof(T));

            using (var stream = new StringReader(xml))
            {
                return (T)serializer.Deserialize(stream);
            }
        }
    }
}
