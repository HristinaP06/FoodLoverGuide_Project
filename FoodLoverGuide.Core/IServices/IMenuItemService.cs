using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Http;

namespace FoodLoverGuide.Core.IServices
{
    public interface IMenuItemService : IService<MenuItem>
    {
        Task<Guid> AddRestaurantPhoto(Guid restaurantId, IFormFile file, string url);

        Task UpdateMenuItemPhotoAsync(Guid menuItemId, IFormFile file, string url);
    }
}
