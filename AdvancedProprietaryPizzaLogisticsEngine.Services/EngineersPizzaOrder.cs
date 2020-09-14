using AdvancedProprietaryPizzaLogisticsEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedProprietaryPizzaLogisticsEngine.Services
{
    public class EngineersPizzaOrder
    {
        public EngineersPizzaOrder()
        {

        }

        /// <summary>
        /// Returns the pizza order for the Engineering Department
        /// </summary>
        /// <param name="items"></param>
        public void PizzaOrder(List<Employee> items)
        {
            try
            {
                var pizzaForAll = items.Where(x => x.department.Contains("Engineering")).Count();
                var pizzaTotal = pizzaForAll / 4;

                Console.WriteLine($"\n");
                Console.WriteLine($"You would need {pizzaTotal} pizzas to feed those hungry Engineers!");
                Console.WriteLine($"Press any key to continue.");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{nameof(EngineersPizzaOrder)}.{nameof(PizzaOrder)} Exception was thrown. Exception Message: {ex.Message}");
            }
        }
    }
}
