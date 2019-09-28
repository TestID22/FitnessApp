using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeptemberFitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeptemberFitness.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllersTests
    {
       

        [TestMethod()]
        public void SaveTest()
        {
            //Arange - объявление (данные которые подаются на вход)
            var userName = Guid.NewGuid().ToString();

            //Act - действие
            var controller = new UserControllers(userName);

            //Assert - равен ли фактический результат - ожидаемому
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            //Arange
            var userName = Guid.NewGuid().ToString();
            var gender = "man";
            var birtdate = DateTime.Now.AddYears(-2);
            var weight = 100;
            var height = 100;
            var controller = new UserControllers(userName);

            //act 
            controller.SetNewUserData(gender, birtdate, weight, height);
            var controller2 = new UserControllers(userName);

            //Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
            Assert.AreEqual(gender, controller.CurrentUser.Gender.Name);
            Assert.AreEqual(birtdate, controller.CurrentUser.BirthDay);
            Assert.AreEqual(weight, controller.CurrentUser.Weight);


        }
    }
}