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
            var eatingController = new EatingController(userController.CurrentUser);

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

            Console.WriteLine("Что вы хотите");
            Console.WriteLine("Ввести ввод пищи");

            var key = Console.ReadKey();
            if(key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);

                foreach(var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine("\t Продукт " + item.Key  + " вес " + item.Value);
                }
            }



            Console.ReadLine();

        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.WriteLine("Введите имя продукта");
            var foodName = Console.ReadLine();

            Console.WriteLine("Введите вес порции");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Калорийность продукта");
            var callories = double.Parse(Console.ReadLine());

            Console.WriteLine("Белки продукта");
            var proteins = double.Parse(Console.ReadLine());

            Console.WriteLine("Жиры продукта");
            var fats = double.Parse(Console.ReadLine());

            Console.WriteLine("Углеводы продукта");
            var carbohydrates = double.Parse(Console.ReadLine()); ;

            var product = new Food(foodName, callories, proteins, fats, carbohydrates);

            return (product, weight);
        }
    }}
 