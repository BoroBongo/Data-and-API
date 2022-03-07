using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialisationApp
{
    public interface ISerialise
    {

        public void SerialiseToFile<T>(string filePath, T item);
        public T DeserialiseFromFile<T>(string filePath);
    }
}
