using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Core.ViewModels.Restaurant;
using FoodLoverGuide.DataAccess.Repository;
using FoodLoverGuide.Models;
using System.Linq.Expressions;

namespace FoodLoverGuide.Core.Services
{
    public class RestaurantCategoriesService : IRestaurantCategoriesService
    {
        private readonly IRepository repo;

        public RestaurantCategoriesService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task Add(RestaurantCategories entity)
        {
            await this.repo.AddAsync(entity);
        }

        public async Task Delete(Guid id)
        {
            await this.repo.DeleteAsync<RestaurantCategories>(id);
        }

        public async Task<List<RestaurantCategories>> Find(Expression<Func<RestaurantCategories, bool>> filter)
        {
            return await this.repo.FindAsync(filter);
        }

        public IQueryable<RestaurantCategories> GetAll()
        {
            return this.repo.GetAllAsync<RestaurantCategories>();
        }

        public async Task<RestaurantCategories> GetById(Guid id)
        {
            return await this.repo.GetByIdAsync<RestaurantCategories>(id);
        }

        public async Task Update(RestaurantCategories entity)
        {
            await this.repo.UpdateAsync(entity);
        }

		public async Task AddRestaurantCategories(AddCategoryToRestaurantVM model)
		{
			foreach (var cat in model.SelectedCategoriesIds)
			{
				var restCat = new RestaurantCategories()
				{
					CategoryId = cat,
					RestaurantId = model.RestaurantId
				};

				await this.repo.AddAsync(restCat);
			}
		}
	}
}
