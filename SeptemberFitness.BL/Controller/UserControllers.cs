using SeptemberFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SeptemberFitness.BL.Controller
{   
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserControllers
    {
        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public User CurrentUser { get; }

        public List<User> Users { get; }

        /// <summary>
        /// Создать контроллер нового пользователя.
        /// </summary>
        /// <param name="user"></param>
        public UserControllers(string name)
        {
            if(name == null)
            {
                throw new ArgumentNullException("Юзер не может быть Null", nameof(name));
            }

            
        }
        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users); //serialize 
            }
        }
        /// <summary>
        /// Получить данные пользователя.
        /// </summary>
        /// <returns></returns>
        public List<User> Load()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is List<User> Users)
                {
                    return Users;

                }
                    return null;
            }
        }
    }
}
