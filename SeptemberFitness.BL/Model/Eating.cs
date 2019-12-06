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
        public int Id { get; set; }
        /// <summary>
        /// Время приёма.
        /// </summary>
        public DateTime Moment{ get; set; }
        /// <summary>
        /// Список еды.
        /// </summary>
        public Dictionary <Food, double> Foods { get; set; }

        public int UserID { get; set; }

        public virtual User User { get; set; }

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
