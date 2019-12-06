using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeptemberFitness.BL.Model
{
    [Serializable]
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; }

        public double CaloriesPerMinute { get; }

        public Activity(string name, double caloriesPerMinute)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("укажите активность", nameof(name));
            }
            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
