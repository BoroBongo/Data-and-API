using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SerialisationApp
{
    public class SerialiserJSON : ISerialise
    {
        public T DeserialiseFromFile<T>(string filePath)
        {

            T output;
            StreamReader sr = File.OpenText(filePath);
            try
            {
                output = JsonConvert.DeserializeObject<T>(sr.ReadToEnd());
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                sr.Close();
            }
            return output;
        }

        public void SerialiseToFile<T>(string filePath, T item)
        {
            // create a BinaryFormatter object, and use it to serialize the item to file
            string jsonContent = JsonConvert.SerializeObject(item, Formatting.Indented);

            File.WriteAllText(filePath, jsonContent);
            // explain that binary serialisation has been deprected in .NET5 due to security concerns
            // we are still covering it for completeness - you may see it in older programs
        }
    }
}
