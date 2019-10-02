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
    class EatingController
    {
        private readonly User user;

        public List<Food> Foods { get; }

        public EatingController(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException("Юзер не может быть Null", nameof(user));
            }
            this.user = user;
            Foods = GetAllFoods();
        }

        private List<Food> GetAllFoods()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("foods.dat", FileMode.OpenOrCreate)) 
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is List<Food> foods)
                {
                    return foods;
                }
                else return new List<Food>();
            }
        }
    }
}
