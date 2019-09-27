using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeptemberFitness.BL.Model;
using SeptemberFitness.BL.Controller;


namespace SeptemberFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "FitnessApp by September";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Вас приветствует Финтнес приложение Нового Поколения");
            Console.WriteLine("Введите свои корректные данные");

            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();

            var userController = new UserControllers(name);
            if (userController.IsNewUser)
            {
                Console.WriteLine("пол");
                var gender = Console.ReadLine();

                Console.WriteLine("дата");
                var dateTime = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("вес");
                var weight = double.Parse(Console.ReadLine());

                Console.WriteLine("рост");
                var height = double.Parse(Console.ReadLine());

                userController.SetNewUserData(gender, dateTime, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();

        }
    }
}
 