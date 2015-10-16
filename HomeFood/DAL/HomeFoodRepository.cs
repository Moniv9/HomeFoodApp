using System;
using MongoDB;
using MongoDB.Driver;
using MongoDB.Driver.Core.Servers;
using MongoDB.Driver.Core;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using System.Web.Configuration;
using HomeFood.Models;
using System.Collections.Generic;
using System.Linq;
using System.Collections;


namespace HomeFood.DAL
{
    public class HomeFoodRepository : IHomeFoodRepository
    {
        private readonly string _connectionString;
        private readonly IMongoDatabase _homeFoodDB;

        public HomeFoodRepository()
        {
            _connectionString = WebConfigurationManager.AppSettings["mongo_connection"];
            _homeFoodDB = new MongoClient(_connectionString).GetDatabase("HomeFoodDB");
        }


        #region Add

        public void RegisterFoodProvider(FoodProviderModel foodProvider)
        {
            _homeFoodDB.GetCollection<FoodProviderModel>(Collections.FoodProviderCollection).InsertOneAsync(foodProvider);
        }


        public void AddFoodItem(FoodModel foodModel)
        {
            _homeFoodDB.GetCollection<FoodModel>(Collections.VirtualHotelCollection).InsertOneAsync(foodModel);
        }


        public void BookOrder(ConsumerModel consumerOrder)
        {
            _homeFoodDB.GetCollection<ConsumerModel>(Collections.ConsumerCollection).InsertOneAsync(consumerOrder);
        }




        #endregion


        #region Update

        public void UpdateRating(string providerPhone, int rating)
        {
            var foodProviderCollection = _homeFoodDB.GetCollection<FoodProviderModel>(Collections.FoodProviderCollection);
            var filter = Builders<FoodProviderModel>.Filter.Eq("Id", providerPhone);
            var update = Builders<FoodProviderModel>.Update.Set("Rating", rating);
            foodProviderCollection.UpdateOneAsync(filter, update);

        }

        #endregion


        #region Get

        public FoodProviderModel GetUser(string providerPhone, string password="")
        {
            var foodProviderCollection = _homeFoodDB.GetCollection<FoodProviderModel>(Collections.FoodProviderCollection);
            if (string.IsNullOrEmpty(password))
            {
                return foodProviderCollection.Find(x => x.Id == providerPhone).FirstOrDefaultAsync().Result;
            }
            else
            {
                return foodProviderCollection.Find(x => x.Id == providerPhone && x.Password == password).FirstOrDefaultAsync().Result;
            }            
        }


        public void GetMenuItem(int foodId)
        {
            
        }


        public IEnumerable<dynamic> GetVirtualHotels(string city)
        {
            var foodProviderCollection = _homeFoodDB.GetCollection<FoodProviderModel>(Collections.FoodProviderCollection);
            return foodProviderCollection.Find(x => x.City.Contains(city)).ToListAsync().Result;
        }


        public IEnumerable<ConsumerModel> GetOrders(string providerPhone)
        {
            var consumerCollection = _homeFoodDB.GetCollection<ConsumerModel>(Collections.ConsumerCollection);
            return consumerCollection.Find(x => x.ProviderId == providerPhone)
                                     .ToListAsync()
                                     .Result.OrderByDescending(x => x.BookDateTime);

        }


        public IEnumerable<FoodModel> GetVirtualHotelDetail(string providerPhone)
        {
            var virtualHotelCollection = _homeFoodDB.GetCollection<FoodModel>(Collections.VirtualHotelCollection);
            return virtualHotelCollection.Find(x => x.ProviderPhone == providerPhone).ToListAsync().Result;
        }


        #endregion

    }
}