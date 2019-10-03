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
    class EatingController : ControllerBase
    {
        private readonly User user;

        private const string FOODS_FILENAME = "foods.dat";
        private const string EATINGS_FILENAME = "";

        public List<Food> Foods { get; }

        public List<Eating> Eatings{ get;}

        public EatingController(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException("Юзер не может быть Null", nameof(user));
            }
            this.user = user;

            Foods = GetAllFoods();
            Eatings = GetAllEatings();
        }
        
        private List<Food> GetAllFoods()
        {
            return Load <List<Food>>(FOODS_FILENAME) ?? new List<Food>();
        }
        private List<Eating> GetAllEatings()
        {
            return Load<List<Eating>>(EATINGS_FILENAME) ?? new List<Eating>();
        }

        
        private void Save()
        {
            Save(FOODS_FILENAME, Foods);
            Save(EATINGS_FILENAME, Eatings);
        }

        public bool Add(string foodname, double weight)
        {
            var food = Foods.SingleOrDefault(f => f.Name == foodname);
            var eating = new Eating(user);
        }

    }
}
