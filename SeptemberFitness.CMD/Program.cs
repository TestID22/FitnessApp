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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Вас приветствует Финтнес приложение Нового Поколения");
            Console.WriteLine("Введите свои корректные данный");

            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();

            Console.WriteLine("Введите ваш пол");
            var gender = Console.ReadLine();

            Console.WriteLine("Введите дату рождения в формате dd.MM.yyyy");
            var birthdate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Ваш вес");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Ваш рост");
            var height = double.Parse(Console.ReadLine());

            var userController = new UserControllers(name, gender, birthdate, weight, height);
            userController.Save();

        }
    }
}
