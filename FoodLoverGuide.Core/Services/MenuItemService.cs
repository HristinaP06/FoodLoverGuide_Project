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

        public async Task<Guid> AddRestaurantMenuPhotoAsync(Guid restaurantId, IFormFile file, string url, int order)
        {
            string uploadedImageUrl = null;

            if (file != null)
            {
                uploadedImageUrl = await cloudinary.UploadImageAsync(file);
            }
            else if (!string.IsNullOrEmpty(url))
            {
                uploadedImageUrl = url;
            }

            if (!string.IsNullOrEmpty(uploadedImageUrl))
            {
                var photo = new MenuItem
                {
                    RestaurantId = restaurantId,
                    Photo = uploadedImageUrl,
                    ImageFile = file,
                    Order = order
                };

                await this.repo.AddAsync(photo);
            }

            return restaurantId;
        }

        public async Task UpdateMenuItemPhotoAsync(Guid menuItemId, IFormFile file, string url)
        {
            var item = await this.repo.GetByIdAsync<MenuItem>(menuItemId);
            if (item == null)
            {
                throw new ArgumentException("Menu item not found.");
            }

            string uploadedImageUrl = null;

            if (file != null)
            {
                uploadedImageUrl = await cloudinary.UploadImageAsync(file);
            }
            else if (!string.IsNullOrEmpty(url))
            {
                uploadedImageUrl = url;
            }

            if (!string.IsNullOrEmpty(uploadedImageUrl))
            {
                item.Photo = uploadedImageUrl;
                item.ImageFile = file;
                await this.repo.UpdateAsync(item);
            }
        }

    }
}
