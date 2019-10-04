using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeptemberFitness.BL.Model
{
    [Serializable]
    /// <summary>
    /// Приём пищи.
    /// </summary>
    public class Eating
    {
        /// <summary>
        /// Время приёма.
        /// </summary>
        public DateTime Moment{ get;}
        /// <summary>
        /// Список еды.
        /// </summary>
        public Dictionary <Food, double> Foods { get;}

        public User User { get; }

        public Eating(User user)
        {
            if (user is null)
            {
                throw new ArgumentNullException("Юзер не может быть пустым, ведь он ЮЗЕР!!!", nameof(user));
            }
            User = user;
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }

        public void FoodAdd(Food food , double weight)
        {

            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food));  //проверка на вхождение продукта
            if(product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }
        }
    }
}
