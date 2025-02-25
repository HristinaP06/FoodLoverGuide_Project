using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodLoverGuide.Core.ViewModels.Restaurant;
using FoodLoverGuide.Models;

namespace FoodLoverGuide.Core.IServices
{
    public interface IRestaurantFeatureService : IService<RestaurantFeature>
    {
        Task<Guid> AddRestaurantFeatures(AddFeatureToRestaurantVM model);
    }
}
