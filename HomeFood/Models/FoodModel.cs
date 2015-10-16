using System;
using MongoDB.Bson;

namespace HomeFood.Models
{
    public class FoodModel
    {
        public ObjectId Id { get; set; }
        public string ProviderPhone { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
    }

}