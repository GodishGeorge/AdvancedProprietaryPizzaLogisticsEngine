using AdvancedProprietaryPizzaLogisticsEngine.Models;
using AdvancedProprietaryPizzaLogisticsEngine.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace AdvancedProprietaryPizzaLogisticsEngine
{
    class Program
    {        
        static void Main(string[] args)
        {
            var _pineappleLovers = new PineappleLovers();
            var _engineersPizzaOrder = new EngineersPizzaOrder();
            var _favortieToppings = new FavoriteToppings();

            var jsonPath = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\netcoreapp3.1\Data.json"));           

            var items = JsonConvert.DeserializeObject<List<Employee>>(jsonPath);

            _pineappleLovers.PineapplePizza(items);

            _engineersPizzaOrder.PizzaOrder(items);

            _favortieToppings.FavoriteToppingsByDepartment(items);                      

            Console.ReadKey();
        }
    }
}
