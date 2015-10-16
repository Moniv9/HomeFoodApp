using System;


namespace HomeFood.Models
{
    public class FoodProviderModel
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int Rating { get; set; }
        public float Longititde { get; set; }
        public float Latitude { get; set; }

    }

}