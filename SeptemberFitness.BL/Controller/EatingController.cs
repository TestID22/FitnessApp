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
    /// Справочник еды.
    /// </summary>
    public class EatingController : ControllerBase
    {
        private readonly User user;

        private const string FOODS_FILENAME = "foods.dat";
        private const string EATINGS_FILENAME = "eatings.dat";

        public List<Food> Foods { get; } //список Различных Продуктов

        public Eating Eating { get; } // Приём Пищи

        public EatingController(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException("Юзер не может быть Null", nameof(user));
            }
            this.user = user;

            Foods = GetAllFoods();
            Eating = GetEating();
        }
        

        private List<Food> GetAllFoods()
        {
            return Load <List<Food>>(FOODS_FILENAME) ?? new List<Food>();
        }
        private Eating GetEating()
        {
            return Load<Eating>(EATINGS_FILENAME) ?? new Eating(user);
        }

        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if(food != null)
            {
                Foods.Add(food);
                Eating.FoodAdd(food, weight);
                Save();
            }
            else
            {
                Eating.FoodAdd(product, weight);
                Save();
            }
        }

        private void Save()
        {
            Save(FOODS_FILENAME, Foods);
            Save(EATINGS_FILENAME, Eating);
        }

    }
}
