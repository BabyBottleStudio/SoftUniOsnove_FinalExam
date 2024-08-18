using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_WildZoo
{
    class Animal
    {
        string name;
        int foodNeeded;
        string area;

        public string Name { get => name; set => name = value; }
        public int FoodNeeded { get => foodNeeded; set => foodNeeded = value; }
        public string Area { get => area; set => area = value; }

        public Animal(string name, int foodNeeded, string area)
        {
            Name = name;
            FoodNeeded = foodNeeded;
            Area = area;
        }
    }

    static class Zoo
    {
        public static Dictionary<string, Animal> AnimalList = new Dictionary<string, Animal>();

        public static Dictionary<string, int> Areas = new Dictionary<string, int>();


        public static void AddAnimal(string name, int foodQuantity, string area)
        {
            if (AnimalList.ContainsKey(name))
            {
                AnimalList[name].FoodNeeded += foodQuantity;
            }
            else
            {
                AnimalList.Add(name, new Animal(name, foodQuantity, area));


                // area handling
                if (!Areas.ContainsKey(area))
                {
                    Areas.Add(area, 1);
                }
                else
                {
                    Areas[area]++;
                }

            }
        }

        public static void FeedAnimal(string name, int foodQuantity)
        {
            if (AnimalList.ContainsKey(name)) // !!!!!!!
            {
                AnimalList[name].FoodNeeded -= foodQuantity;

                if (AnimalList[name].FoodNeeded <= 0)
                {
                    Console.WriteLine($"{name} was successfully fed");

                    // area handling
                    string tempArea = AnimalList[name].Area;
                    if (Areas[tempArea] <= 1)
                    {
                        Areas.Remove(tempArea);
                    }
                    else
                    {
                        Areas[tempArea]--; 
                    }
                    
                    AnimalList.Remove(name);

                    
                }
            }
        }


        public static void PrintHungryAnimals()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine("Animals:");

            foreach(string key in AnimalList.Keys)
            {
                output.AppendLine($" {AnimalList[key].Name} -> {AnimalList[key].FoodNeeded}g");
            }

            Console.Write(output.ToString());

        }

        public static void PrintAreasWithHungryAnimals()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine("Areas with hungry animals:");

            foreach (string key in Areas.Keys)
            {
                output.AppendLine($" {key}: {Areas[key]}");
            }

            Console.Write(output.ToString());

        }

        

    }

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if(Equals(input, "EndDay"))
                {
                    break;
                }

                List<string> data = input.Split(new string[] { ": " }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string command = data[0];

                List<string> animalData = data[1].Split('-').ToList();

                string animalName = animalData[0];
                int foodAmount = int.Parse(animalData[1]);

                switch (command)
                {
                    case "Add":
                        string areaName = animalData[2];
                        Zoo.AddAnimal(animalName, foodAmount, areaName);
                        break;

                    case "Feed":
                        Zoo.FeedAnimal(animalName, foodAmount);
                        break;
                }

            }// while end

            Zoo.PrintHungryAnimals();
            Zoo.PrintAreasWithHungryAnimals();

        }
    }
}
