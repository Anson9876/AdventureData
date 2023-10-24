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
                Console.WriteLine("These are the cars you can afford");



                var cars = accessLayer.GetAllCars(bud);
                foreach (var car in cars)
                {
                    Console.WriteLine($"Make: {car.Make}, Model:{car.Model}, Year: {car.Year} , Price: {car.Price}"); 
                }
                
            }
            if (num == "2")
            {
                var phones = accessLayer.GetAllPhones();
                foreach (var phone in phones)
                {
                    Console.WriteLine(phone.Make);
                }
            }


            if (num == "3")
            {
                var sports = accessLayer.GetAllSports();
                foreach (var sport in sports)
                {
                    Console.WriteLine(sport.Name);
                }
            }
        }

        static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("AppSettings.json", optional: false, reloadOnChange: true);
            _iconfiguration = builder.Build();
        }
         
    }
}