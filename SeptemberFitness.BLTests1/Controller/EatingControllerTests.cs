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
    public class EatingControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();
            var rnd = new Random();

            var userController = new UserControllers(userName);
            var eatingController = new EatingController(userController.CurrentUser);

            var food = new Food(foodName, rnd.Next(100, 500), rnd.Next(100, 500), rnd.Next(100, 500), rnd.Next(100, 500));

            //Act
            eatingController.Add(food, 100);

            //Assert
            Assert.AreEqual(food, eatingController.Eating.Foods.First().Key.Name);
        }
    }
}