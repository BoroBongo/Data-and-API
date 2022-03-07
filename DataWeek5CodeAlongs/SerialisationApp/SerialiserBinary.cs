using System.Collections;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
// warning - binary formatter is now obselete as of .NET5.0namespace SerialisationApp
namespace SerialisationApp
{
    public class SerialiserBinary : ISerialise
{

    public void SerialiseToFile<T>(string filePath, T item)
    {
        FileStream fileStream = File.Create(filePath);
        // create a BinaryFormatter object, and use it to serialize the item to file
        BinaryFormatter writer = new BinaryFormatter();
        writer.Serialize(fileStream, item);
        // explain that binary serialisation has been deprected in .NET5 due to security concerns
        // we are still covering it for completeness - you may see it in older programs
        fileStream.Close();
    }

        public T DeserialiseFromFile<T>(string filePath)
        {

                T output;
            FileStream fs = new FileStream(filePath, FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                output = (T)formatter.Deserialize(fs);
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
    }
}