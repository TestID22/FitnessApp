using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SeptemberFitness.BL.Controller
{ 
    public abstract class ControllerBase
    {
        //Реализация Dependecy Injection через интерфейс TO DO: ADD DataBaseSaver Entity Framework
        protected IDataSaver saver = new SerializeDataSaver();

        protected void Save(string fileName, Object obj)
        {
            saver.Save(fileName, obj);
        }
       
        //Возвращаем любой тип Т, при использовании метода указываем загружаеммый ТИП данных.
        protected T Load<T>(string fileName)
        {
            return saver.Load<T>(fileName);
        }
    }
}
