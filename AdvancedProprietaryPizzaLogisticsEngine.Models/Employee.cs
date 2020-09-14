using System;
using System.Collections.Generic;

namespace AdvancedProprietaryPizzaLogisticsEngine.Models
{
    public class Employee
    {
        public string name { get; set; }
        public string department { get; set; }
        public List<string> toppings { get; set; }
    }
}
