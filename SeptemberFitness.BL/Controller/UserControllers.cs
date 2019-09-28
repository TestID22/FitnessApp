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
        /// <summary>
        /// Список всех пользователей.
        /// </summary>
        public List<User> Users { get; }

        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Создать контроллер нового пользователя.
        /// </summary>
        /// <param name="user">Имя пользователя.</param>
        public UserControllers(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Юзер не может быть Null", nameof(name));
            }
            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == name);
            if(CurrentUser == null)
            {
                CurrentUser = new User(name);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
            
        }

        //Сереализация.
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users); //serialize 
            }
        }
      
        //Десереализация.
        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is List<User> Users)
                {
                    return Users;

                }
                    return new List<User>();
            }
        }
        
        //Созать пользователя. Если он новый.
        public void SetNewUserData(string gender, DateTime birthdate, double weight , double height )
        {
            CurrentUser.Gender = new Gender(gender);
            CurrentUser.BirthDay = birthdate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save(); //не забывай сереализовать нового пользователя.
        }
    }
}
