using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeptemberFitness.BL.Model
{
    public class Food
    {
        public string Name { get; }
        /// <summary>
        /// Калории.
        /// </summary>
        public double Calories { get; }
        /// <summary>
        /// Белки.
        /// </summary>
        public double Proteins{ get; }
        /// <summary>
        /// Жиры.
        /// </summary>
        public double Fats { get; }
        /// <summary>
        /// Углеводы.
        /// </summary>
        public double Carbohydrates { get; }

    

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

        public override string ToString() => Name;
           
     
    }
}
