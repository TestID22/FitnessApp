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
        public User User { get; }

        /// <summary>
        /// Создать контроллер нового пользователя.
        /// </summary>
        /// <param name="user"></param>
        public UserControllers(string userName, string genderName, DateTime birthdate, double weight, double height)
        {
            //конструктор упаковывает класс User 
            Gender gender = new Gender(genderName);
            User = new User(userName, gender, birthdate, weight, height);
           
        }
        /// <summary>
        /// Получить данные пользователя.
        /// </summary>
        /// <returns></returns>
        /// 
        public UserControllers()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dar", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                {
                    User = user;

                }
                // TODO : Что делать если не считали пользователя.
            }
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

        
    }
}
