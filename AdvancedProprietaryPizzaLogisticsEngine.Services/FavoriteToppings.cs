using AdvancedProprietaryPizzaLogisticsEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedProprietaryPizzaLogisticsEngine.Services
{
    public class FavoriteToppings
    {
        public FavoriteToppings()
        {

        }

        /// <summary>
        /// Returns a all favorite toppings by department
        /// </summary>
        /// <param name="items"></param>
        public void FavoriteToppingsByDepartment(List<Employee> items)
        {
            try
            {
                var pizzaCombinationsList = items.OrderBy(o => o.department).GroupBy(b => b.toppings)
                    .OrderByDescending(g => g.Count())
                    .Select(s => new { Topping = s.Key, Count = s.Count() }).ToList();

                var departments = items.GroupBy(g => g.department).ToList();

                foreach (var department in departments)
                {                   
                    var toppingList = new List<string>();

                    foreach (var topping in department.Select(s2 => s2.toppings.OrderBy(o => o)).ToList())
                    {                       
                        var combineToppings = String.Join(" and ", topping.Select(s => s));
                        toppingList.Add(combineToppings);
                    }

                    var toppingsGrouped = toppingList.GroupBy(o => o)
                        .OrderByDescending(g => g.Count())
                        .Select(s => new { Toppings = s.Key, Count = s.Count() }).ToList();

                    var toppings = toppingsGrouped.Where(x => x.Count == toppingsGrouped.Select(s => s.Count).FirstOrDefault()).ToList();

                    if (toppings.Count > 1)
                    {
                        Console.WriteLine($"\n");
                        Console.WriteLine($"{department.Key} Department");
                        foreach (var topping in toppings)
                        {
                            Console.WriteLine($"Topping Combination: {topping.Toppings}, Employee Approved: {topping.Count}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"\n");
                        Console.WriteLine($"{department.Key} Department");
                        Console.WriteLine($"Topping Combination: {toppings.FirstOrDefault().Toppings}, Employee Approved: {toppings.FirstOrDefault().Count}");
                    }
                }

                Console.WriteLine($"Press any key to continue.");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{nameof(FavoriteToppings)}.{nameof(FavoriteToppingsByDepartment)} Exception was thrown. Exception Message: {ex.Message}");
            }
        }
    }
}
