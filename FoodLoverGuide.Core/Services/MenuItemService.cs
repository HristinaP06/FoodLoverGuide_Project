using CloudinaryDotNet;
using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Core.ViewModels.Restaurant;
using FoodLoverGuide.DataAccess.Repository;
using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace FoodLoverGuide.Core.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IRepository repo;
        private readonly CloudinaryService cloudinary;

        public MenuItemService(IRepository repo, CloudinaryService cloudinary)
        {
            this.repo = repo;
            this.cloudinary = cloudinary;
        }

        public async Task Add(MenuItem entity)
        {
            await this.repo.AddAsync(entity);
        }

        public async Task Delete(Guid id)
        {
            await this.repo.DeleteAsync<MenuItem>(id);
        }

        public async Task<List<MenuItem>> Find(Expression<Func<MenuItem, bool>> filter)
        {
            return await this.repo.FindAsync(filter);
        }

        public IQueryable<MenuItem> GetAll()
        {
            return this.repo.GetAllAsync<MenuItem>();
        }

        public async Task<MenuItem> GetById(Guid id)
        {
            return await this.repo.GetByIdAsync<MenuItem>(id);
        }

        public async Task Update(MenuItem entity)
        {
            await this.repo.UpdateAsync(entity);
        }

        public async Task<Guid> AddRestaurantPhoto(Guid restaurantId, IFormFile file, string url)
        {
            string uploadedImageUrl = null;

            // Handle file upload to Cloudinary
            if (file != null)
            {
                uploadedImageUrl = await cloudinary.UploadImageAsync(file); // Upload to Cloudinary
            }
            // Handle URL input from the user
            else if (!string.IsNullOrEmpty(url))
            {
                uploadedImageUrl = url; // Use the provided URL
            }

            if (!string.IsNullOrEmpty(uploadedImageUrl))
            {
                var photo = new MenuItem
                {
                    RestaurantId = restaurantId,
                    Photo = uploadedImageUrl,
                    ImageFile = file // We still store the file even though URL is provided (optional)
                };

                await this.repo.AddAsync(photo); // Save the photo in the database
            }

            return restaurantId;
        }
    }
}
