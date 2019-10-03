using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SeptemberFitness.BL.Controller
{/// <summary>
/// В базовом классе вынесены методы сереализации и десереализации 
/// используя дженерики для Типов User, Food, EaTING
/// </summary>
    public abstract class ControllerBase
    {
        /// <summary>
        /// Обобщённый метод для Сериализации Юзеров и для Сохранения еды.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="obj"></param>
        protected void Save(string fileName, Object obj)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj); //serialize 
            }
        }
       
        //Возвращаем любой тип Т, при использовании метода указываем загружаеммый ТИП данных.
        protected T Load<T>(string fileName)
        {
            var formatter = new BinaryFormatter();

            using(var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is T item)
                {
                    return item;
                }
                return default(T);
            }
        }
    }
}
