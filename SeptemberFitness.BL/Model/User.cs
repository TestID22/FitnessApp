using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeptemberFitness.BL.Model
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    class User
    {
        #region Properties
        /// <summary>
        /// Имя.
        /// </summary>
        public string  Name { get; }
        /// <summary>
        /// Пол.
        /// </summary>
        public Gender Gender { get;}
        /// <summary>
        /// День Рождения.
        /// </summary>
        public DateTime BirthDay { get;}
        /// <summary>
        /// Вес.
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Рост.
        /// </summary>
        public double Height { get; set; }
        #endregion

        
        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        /// <param name="name"> Имя. </param>
        /// <param name="birthDay"> Дата рождения. </param>
        /// <param name="gender"> Пол. </param>
        /// <param name="weight"> Вес. </param>
        /// <param name="height"> Рост. </param>
        public User(string name, DateTime birthDay, Gender gender, double weight, double height)
        {
            #region Проверка условий
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или Null", nameof(name));
            }
            if (gender == null)
            {
                throw new ArgumentNullException("Пол не может быть Null", nameof(name));
            }
            if (BirthDay < DateTime.Parse("01.01.1950") || BirthDay > DateTime.Now)
            {
                throw new ArgumentNullException("Дата невозможна", nameof(birthDay));
            }
            if(Weight <= 0)
            {
                throw new ArgumentNullException("Вес не может быть 0", nameof(weight));
            }
            if(Height <= 0)
            {
                throw new ArgumentNullException("Рост не может быть 0", nameof(height));
            }
            #endregion

            Name = name;
            BirthDay = birthDay;
            Gender = gender;
            Weight = weight;
            Height = height;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
