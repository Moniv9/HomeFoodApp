using System;
using HomeFood.Models;
using System.Collections.Generic;



namespace HomeFood.DAL
{
    public interface IHomeFoodRepository
    {
        void RegisterFoodProvider(FoodProviderModel foodProvider);

        FoodProviderModel GetUser(string providerPhone, string password="");

        void AddFoodItem(FoodModel virtualHotel);

        void UpdateRating(string providerPhone, int rating);

        IEnumerable<dynamic> GetVirtualHotels(string city);

        IEnumerable<FoodModel> GetVirtualHotelDetail(string providerPhone);
    }
}
