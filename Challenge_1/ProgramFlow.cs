using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1
{
    public class ProgramFlow
    {
        private MenuRepository _menuRepository;

        public ProgramFlow()
        {
            _menuRepository = new MenuRepository();
        }

        public void Run()
        {
            Console.WriteLine("Komodo Cafe");
            Console.WriteLine("=====================");
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("\n--------------------");
                Console.WriteLine("Choose a menu item:");
                Console.WriteLine("--------------------");
                Console.WriteLine("1. Create Menu Item");
                Console.WriteLine("2. Delete a Menu Item");
                Console.WriteLine("3. List all Items");
                string inputString = Console.ReadLine();
                if (int.TryParse(inputString, out int input))
                {
                    switch (input)
                    {
                        case 1:
                            CreateMenuItem();
                            break;
                        case 2:
                            DeleteMenu();
                            break;
                        case 3:
                            _menuRepository.DisplayMenu();
                            break;
                    }
                }
            }
        }


        private void DeleteMenu()
        {
            Console.Write("\nEnter Meal Number to delete : ");
            var input = Console.ReadLine();
            _menuRepository.DeleteMenuItem(int.Parse(input));
        }
        private void CreateMenuItem()
        {
            Console.Write("Enter a meal number ");
            string mealNumber = Console.ReadLine();
            Console.Write("Enter a meal name: ");
            var name = Console.ReadLine();
            Console.Write("Enter a meal description: ");
            var description = Console.ReadLine();
            Console.Write("Enter a meal price: $");
            var price = Console.ReadLine();
            Console.Write("Enter list of ingredients separated with comma (,): ");
            var ingredients = Console.ReadLine();


            Meal meal = new Meal
            {
                MealNumber = int.Parse(mealNumber),
                MealName = name,
                Description = description,
                ListOfIngredients = ingredients,
                Price = decimal.Parse(price)
            };

            _menuRepository.AddMenuItem(meal);
        }


    }
}
