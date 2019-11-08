using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SeptemberFitness.BL.Controller
{
    class SerializeDataSaver : IDataSaver
    {
        public T Load<T>(string fileName)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is T item)
                {
                    return item;
                }
                return default(T);
            }
        }

        public void Save(string fileName, object obj)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj); //serialize 
            }
        }
    }
}
