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
            FileStream fs = new FileStream(filePath, FileMode.Open);
            try
            {
                output = JsonSerializer.Deserialize<T>(fs);
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
            // create a BinaryFormatter object, and use it to serialize the item to file
            string jsonContent = JsonSerializer.Serialize(item);

            File.WriteAllText(filePath, jsonContent);
            // explain that binary serialisation has been deprected in .NET5 due to security concerns
            // we are still covering it for completeness - you may see it in older programs
        }
    }
}
