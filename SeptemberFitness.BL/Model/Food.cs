using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeptemberFitness.BL.Model
{
    [Serializable]
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Калории.
        /// </summary>
        public double Calories { get; set; }
        /// <summary>
        /// Белки.
        /// </summary>
        public double Proteins{ get; set; }
        /// <summary>
        /// Жиры.
        /// </summary>
        public double Fats { get; set; }
        /// <summary>
        /// Углеводы.
        /// </summary>
        public double Carbohydrates { get; set; }

        public Food(string name) : this (name, 0, 0, 0, 0)
        {
            //TODO: проверка
        }

        public Food(string name, double calories ,double proteins, double fats, double carbohydrates)
        {
            //TODO : Проверка.
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Имя не может быть пустым или Null", nameof(name));
            }


            Name = name;
            Calories = calories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
        }

        public override string ToString()  => Name;
           
     
    }
}
