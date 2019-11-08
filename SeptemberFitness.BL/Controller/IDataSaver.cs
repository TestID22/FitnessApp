using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Интерфейс для реализации Внедрения Зависимотсей.
namespace SeptemberFitness.BL.Controller
{
    public interface IDataSaver
    {
        void Save(string fileName, Object obj);
        T Load<T>(string fileName);
    }
}
