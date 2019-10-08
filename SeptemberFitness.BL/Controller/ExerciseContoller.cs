using SeptemberFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeptemberFitness.BL.Controller
{
    public class ExerciseContoller : ControllerBase
    {
        private readonly User user;

        public List<Exercise> Exercises;
        public List<Activity> Activities;

        private const string EXERCISES_FILE_NAME = "exercises.dat";

        private const string ACTIVITIES_FILE_NAME = "activities.dat";

        public ExerciseContoller(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Юзер не может быть Null", nameof(user));

            //Подгрузим Активность и Упражнения.
            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

        public void Add(Activity activity, DateTime begin, DateTime end)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);
            if (act == null)
            {
                Activities.Add(activity);
                var exercise = new Exercise(begin, end, activity, user);
                Exercises.Add(exercise);
            }
            else
            {
                var exercise = new Exercise(begin, end, act, user);
                Exercises.Add(exercise);
            }
            Save();
        }

        private List<Activity> GetAllActivities()
        {
            return Load<List<Activity>>(ACTIVITIES_FILE_NAME) ?? new List<Activity>();
        }



        private List<Exercise> GetAllExercises()
        {
            return Load<List<Exercise>>(EXERCISES_FILE_NAME) ?? new List<Exercise>();
        }

        private void Save()
        {
            Save(EXERCISES_FILE_NAME, Exercises);
        }
    }
}
