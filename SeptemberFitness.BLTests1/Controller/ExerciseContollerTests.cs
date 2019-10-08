using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeptemberFitness.BL.Controller;
using SeptemberFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeptemberFitness.BL.Controller.Tests
{
    [TestClass()]
    public class ExerciseContollerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            var userName = Guid.NewGuid().ToString();
            var activityName = Guid.NewGuid().ToString();
            var rnd = new Random();

            var userController = new UserControllers(userName);

            var exController= new ExerciseContoller(userController.CurrentUser);

            var activity = new Activity(activityName, rnd.Next(50, 500));

            //Act
            exController.Add(activity, DateTime.Now, DateTime.Now.AddHours(1));

            //Assert
            Assert.AreEqual(activityName, exController.Activities.First().Name);
        }
    }
}