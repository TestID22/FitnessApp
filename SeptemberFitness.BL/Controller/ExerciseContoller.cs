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

            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

        private List<Activity> GetAllActivities()
        {
            return Load<List<Activity>>(ACTIVITIES_FILE_NAME) ?? new List<Activity>();
        }

        public void Add(string activityName, DateTime begin, DateTime end)
        {

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
