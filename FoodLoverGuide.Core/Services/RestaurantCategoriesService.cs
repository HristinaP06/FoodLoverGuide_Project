using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Core.ViewModels.Restaurant;
using FoodLoverGuide.DataAccess.Repository;
using FoodLoverGuide.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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

		public async Task<Guid> AddRestaurantCategoriesAsync(AddCategoryToRestaurantVM model)
		{
            var addedRestaurantCategories = this.repo.GetAllAsync<RestaurantCategories>().Where(r => r.RestaurantId == model.RestaurantId).Select(r => r.CategoryId);

			foreach (var cat in model.SelectedCategoriesIds.Where(r => !addedRestaurantCategories.Contains(r)))
			{
				var restCat = new RestaurantCategories()
				{
					CategoryId = cat,
					RestaurantId = model.RestaurantId
				};

				await this.repo.AddAsync(restCat);
			}

            return model.RestaurantId;
		}

        public async Task<Guid> UpdateRestaurantCategoriesAsync(AddCategoryToRestaurantVM model)
        {
            var existingCategoryIds = await this.repo
                .GetAllAsync<RestaurantCategories>()
                .Where(r => r.RestaurantId == model.RestaurantId)
                .Select(r => r.CategoryId)
                .ToListAsync();

            var selectedCategoryIds = model.SelectedCategoriesIds ?? new List<Guid>();
            var categoriesToAdd = selectedCategoryIds.Except(existingCategoryIds);

            foreach (var categoryId in categoriesToAdd)
            {
                var newCategory = new RestaurantCategories
                {
                    RestaurantId = model.RestaurantId,
                    CategoryId = categoryId
                };

                await this.repo.AddAsync(newCategory);
            }

            var categoriesToRemove = existingCategoryIds.Except(selectedCategoryIds);
            foreach (var categoryId in categoriesToRemove)
            {
                var categoryToDelete = await this.repo
                    .GetAllAsync<RestaurantCategories>()
                    .FirstOrDefaultAsync(rf => rf.RestaurantId == model.RestaurantId && rf.CategoryId == categoryId);

                if (categoryToDelete != null)
                {
                    await this.repo.DeleteAsync(categoryToDelete);
                }
            }

            return model.RestaurantId;
        }

        public async Task<List<Guid>> GetCategoryIdsForRestaurantAsync(Guid restaurantId)
        {
            return await this.repo.GetAllAsync<RestaurantCategories>().Where(r => r.RestaurantId == restaurantId).Select(r => r.CategoryId).ToListAsync();
        }
    }
}
