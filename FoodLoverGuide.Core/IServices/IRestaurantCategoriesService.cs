using FoodLoverGuide.Core.ViewModels.Restaurant;
using FoodLoverGuide.Models;

namespace FoodLoverGuide.Core.IServices
{
	public interface IRestaurantCategoriesService : IService<RestaurantCategories>
    {
		Task<Guid> AddRestaurantCategoriesAsync(AddCategoryToRestaurantVM model);

        Task<Guid> UpdateRestaurantCategoriesAsync(AddCategoryToRestaurantVM model);

        Task<List<Guid>> GetCategoryIdsForRestaurantAsync(Guid id);
    }
}
