using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Http;

namespace FoodLoverGuide.Core.IServices
{
    public interface IRestaurantPhotoService : IService<RestaurantPhoto>
    {
        Task<Guid> AddRestaurantPhotoAsync(Guid restaurantId, IFormFile file, string url);

        Task UpdateRestaurantPhotoAsync(Guid id, IFormFile newFile, string newUrl);
    }
}
