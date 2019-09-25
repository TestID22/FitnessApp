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
    class UserControllers
    {
        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Создать контроллер нового пользователя.
        /// </summary>
        /// <param name="user"></param>
        public UserControllers(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException("Юзер не может быть Null", nameof(user));
            }
            User = user;
        }
        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dar", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User); //serialize 
            }
        }
        /// <summary>
        /// Получить данные пользователя.
        /// </summary>
        /// <returns></returns>
        public User Load()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dar", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                {
                    return user;

                }
                    return null;
            }
        }
    }
}
