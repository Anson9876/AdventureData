using AdventureData.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.IO; 

namespace AdventureData
{
    class Program
    {
        private static IConfiguration _iconfiguration;
        static void Main(string[] args)
        {
            GetAppSettingsFile();
            var accessLayer = new DataAccessLayer(_iconfiguration);
            Console.WriteLine("What are you interested in? Press 1 for Cars, 2 for Phones, 3 for Sports.");
            string num = Console.ReadLine();

            if (num == "1")
            {
                Console.WriteLine("What is your budget?");
                string budget = Console.ReadLine();
                int bud = int.Parse(budget);
                Console.WriteLine("These are the cars you can afford:");



                var cars = accessLayer.GetAllCars(bud);
                if (cars.Count == 0)
                {
                    Console.WriteLine("Unfortunately no cars are avaialable with your budget");
                }
                else 
                {
                    foreach (var car in cars)
                    {
                        Console.WriteLine($"Make: {car.Make}, Model:{car.Model}, Year: {car.Year} , Price: {car.Price}");
                    }
                }
                
                
            }
            if (num == "2")
            {
                Console.WriteLine("What is your budget?");
                string budget = Console.ReadLine();
                int bud = int.Parse(budget);
                Console.WriteLine("These are the phones you can afford:");


                var phones = accessLayer.GetAllPhones(bud);
                foreach (var phone in phones)
                {
                    Console.WriteLine($"Make: {phone.Make}, Model:{phone.Model}, Year: {phone.Year} , Price: {phone.Price}");
                }
            }


            if (num == "3")

            {

                Console.WriteLine("How long do you have to play?");
                string time = Console.ReadLine();
                int t = int.Parse(time);
                Console.WriteLine("These are the sports you can play with the time you have:");

                var sports = accessLayer.GetAllSports(t);
                foreach (var sport in sports)
                {
                    Console.WriteLine($"Name: {sport.Name}, Number of players:{sport.PlayerNum}, Duration: {sport.Duration}");
                }
            }
        }
        //function to get the appsettings.json file


        static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("AppSettings.json", optional: false, reloadOnChange: true);
            _iconfiguration = builder.Build();
        }
         
    }
}