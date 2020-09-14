using AdvancedProprietaryPizzaLogisticsEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedProprietaryPizzaLogisticsEngine.Services
{
    public class PineappleLovers
    {
        public PineappleLovers()
        {

        }

        /// <summary>
        /// Returns which department love Pineapple Pizza the most
        /// </summary>
        /// <param name="items"></param>
        public void PineapplePizza(List<Employee> items)
        {
            try
            {
                var pineappleLovers = items.Where(x => x.toppings.Contains("Pineapple")).GroupBy(b => b.department)
                    .OrderByDescending(g => g.Count())
                    .Select(g => new { Department = g.Key, Count = g.Count() })
                    .FirstOrDefault();

                Console.WriteLine($"The {pineappleLovers.Department} Department loves Pineapple on their pizza more than any other department!");
                Console.WriteLine($"Press any key to continue.");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{nameof(PineappleLovers)}.{nameof(PineapplePizza)} Exception was thrown. Exception Message: {ex.Message}");
            }
        }        
    }
}
