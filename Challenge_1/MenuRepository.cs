using System;
using System.Collections.Generic;

namespace Challenge1
{

    public class MenuRepository
    {
        private List<Meal> _menu;

        public MenuRepository()
        {
            _menu = new List<Meal>();
        }

        public void AddMenuItem(Meal meal)
        {
            _menu.Add(meal);
        }

        public void DeleteMenuItem(int mealNumber)
        {
            var meal = _menu.Find(x => x.MealNumber == mealNumber);
            if (meal != null)
            {
                _menu.Remove(meal);
                Console.WriteLine($"meal #{mealNumber} has been deleted from the menu");
            }
            else
                Console.WriteLine("can't find meal #" + mealNumber);
        }

        public void DisplayMenu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("----------------");
            Console.Write(FormatedString("Meal#"));
            Console.Write(FormatedString("Name"));
            Console.Write(FormatedString("Description"));
            Console.Write(FormatedString("Ingredients", 40));
            Console.Write(FormatedString("Price"));

            foreach (var meal in _menu)
            {
                Console.Write(FormatedString("\n" + meal.MealNumber.ToString()));
                Console.Write(FormatedString(meal.MealName.ToString()));
                Console.Write(FormatedString(meal.Description.ToString()));
                Console.Write(FormatedString(meal.ListOfIngredients, 40));
                Console.Write(FormatedString("$" + meal.Price.ToString()));
            }

            Console.WriteLine("\n----------------------------------------------------------");
        }

        private string FormatedString(string str, int padding = 20)
        {
            return str.PadRight(padding, ' ');
        }
    }
}