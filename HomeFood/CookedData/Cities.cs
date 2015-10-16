using System;
using System.Collections.Generic;

namespace HomeFood
{
    public static class Cities
    {
        public static List<string> GetCities()
        {
            var cities = new List<string>(){
              "Noida",
              "Greater Noida",
              "Delhi"
            };

            return cities;
        }
    }
}