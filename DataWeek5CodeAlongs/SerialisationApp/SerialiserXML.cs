using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerialisationApp
{
    public class SerialiserXML : ISerialise
    {
        public T DeserialiseFromFile<T>(string filePath)
        {

            T output;
            FileStream fs = new FileStream(filePath, FileMode.Open);
            try
            {
                XmlSerializer xmlSer = new XmlSerializer(typeof(T));
                output = (T)xmlSer.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
            return output;
        }

        public void SerialiseToFile<T>(string filePath, T item)
        {
            FileStream fileStream = File.Create(filePath);
            // create a BinaryFormatter object, and use it to serialize the item to file
            XmlSerializer xmlSer = new XmlSerializer(typeof(T));
            xmlSer.Serialize(fileStream, item);
            // explain that binary serialisation has been deprected in .NET5 due to security concerns
            // we are still covering it for completeness - you may see it in older programs
            fileStream.Close();
        }
    }
}
