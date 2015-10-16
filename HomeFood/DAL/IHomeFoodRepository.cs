using System;
using HomeFood.Models;



namespace HomeFood.DAL
{
    public interface IHomeFoodRepository
    {
        void RegisterFoodProvider(FoodProviderModel foodProvider);

        FoodProviderModel GetUser(string providerPhone, string password);

        void AddFoodItem(FoodModel virtualHotel);

        void UpdateRating(string providerPhone, int rating);
    }
}
