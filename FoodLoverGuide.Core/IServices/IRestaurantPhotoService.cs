using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodLoverGuide.Core.ViewModels.Restaurant;
using FoodLoverGuide.Models;

namespace FoodLoverGuide.Core.IServices
{
    public interface IRestaurantPhotoService : IService<RestaurantPhoto>
    {
        Task<Guid> AddRestaurantPhoto(AddPhotoRestaurantVM model);
    }
}
