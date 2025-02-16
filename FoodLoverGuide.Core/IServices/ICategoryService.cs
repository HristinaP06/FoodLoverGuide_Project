using FoodLoverGuide.Models;

namespace FoodLoverGuide.Core.IServices
{
    public interface ICategoryService : IService<Category>
    {
        Category GetRestaurantCategory(Guid restaurantId);
    }
}
