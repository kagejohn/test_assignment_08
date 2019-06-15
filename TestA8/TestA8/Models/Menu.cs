using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestA8.Models
{
    public static class Menu
    {
        private static readonly List<Pizza> PizzaMenu = new List<Pizza>();

        static Menu()
        {
            for (int i = 0; i < 100; i++)
            {
                Pizza pizza = new Pizza
                {
                    Name = "Pizza" + i,
                    Description = "Pizza description " + i,
                    Price = 50 + i
                };
                PizzaMenu.Add(pizza);
            }
        }

        public static List<Pizza> Read()
        {
            return PizzaMenu;
        }

        public static List<string> Read(bool pizzaNames)
        {
            if (pizzaNames)
            {
                List<string> pizzaNamesList = new List<string>();

                PizzaMenu.ForEach(p => pizzaNamesList.Add(p.Name));

                return pizzaNamesList;
            }
            return null;
        }
    }
}
