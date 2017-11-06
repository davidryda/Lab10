using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList cars = new ArrayList();

            cars.Add(new Car("Tesla", "Model S", 2017, 74_500));
            cars.Add(new Car("Dodge", "Viper", 2017, 90_495));
            cars.Add(new Car("Dank", "Mobile", 1337, 420.00));
            cars.Add(new UsedCar("Pontiac", "Aztek", 2005, 4_999, 90_000));
            cars.Add(new UsedCar("BMW", "4 Series", 2016, 37_499, 19_000));
            cars.Add(new UsedCar("West", "Batmobile", 1966, 99, 1_000_000));
            cars.Add("Quit");

            for (int i = 0; i < cars.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {cars[i]}");
            }

            bool restart = true;
            while (restart)
            {
                int selection = 0;
                bool chooseCar = true;
                while (chooseCar)
                {
                    Console.Write("Which car would you like to buy? ");
                    string input = Console.ReadLine().Trim();
                    chooseCar = int.TryParse(input, out selection);
                    if (selection == cars.Count)
                    {
                        Environment.Exit(0);
                    }
                    else if (selection < 1 || selection > cars.Count)
                    {
                        Console.WriteLine("Not valid input... Try Again");
                        chooseCar = true;
                    }
                    else
                    {
                        chooseCar = false;
                    }
                }
                Console.WriteLine(cars[selection - 1]);

                Console.Write("Would you like to buy this car? (Y or N): ");
                string answer = Console.ReadLine().ToLower().Trim();
                bool buyCar = true;
                while (buyCar)
                {
                    if (answer == "y")
                    {
                        Console.WriteLine("Alright. I'll remove that from the list...");
                        cars.RemoveAt(selection - 1);
                        buyCar = false;
                        chooseCar = true;
                    }
                    else if (answer == "n")
                    {
                        buyCar = false;
                        chooseCar = true;
                    }
                    else
                    {
                        Console.WriteLine("Not valid input... Try again...");
                        buyCar = true;
                    }
                }

                for (int i = 0; i < cars.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {cars[i]}");
                } 
            }
        }
    }
}
