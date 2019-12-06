using SeptemberFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeptemberFitness.BL.Controller
{
    class DatabaseDataSaver : IDataSaver
    {
        public T Load<T>(string fileName)
        {
            throw new NotImplementedException();
        }

        public void Save(string fileName, object obj)
        {
            using(var db = new FithnessContext())
            {
                var type = obj.GetType();
                if (type == typeof(User))
                {
                    db.Users.Add(obj as User);
                }
                else if (type == typeof(Gender))
                {
                    db.Genders.Add(obj as Gender);
                }
                else if (type == typeof(Food))
                {
                    db.Foods.Add(obj as Food);
                }else if (type == typeof(Exercise))
                {
                    db.Exercises.Add(obj as Exercise);
                }else if(type == typeof(Eating))
                {
                    db.Eatings.Add(obj as Eating);
                }else
                {
                    db.Activities.Add(obj as Activity);
                }
                db.SaveChanges();
            }
        }
    }
}
