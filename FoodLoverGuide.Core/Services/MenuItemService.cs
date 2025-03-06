using CloudinaryDotNet;
using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Core.ViewModels.Restaurant;
using FoodLoverGuide.DataAccess.Repository;
using FoodLoverGuide.Models;
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

        public async Task<Guid> AddRestaurantPhoto(AddPhotoRestaurantVM vM)
        {
            if (vM.File != null)
            {
                var uploadedImageUrl = await cloudinary.UploadImageAsync(vM.File);

                if (!string.IsNullOrEmpty(uploadedImageUrl))
                {
                    vM.Photo = uploadedImageUrl;
                }
            }
            else if (!string.IsNullOrEmpty(vM.Photo))
            // Проверяваме дали е въведен URL
            {
                vM.Photo = vM.Photo;
                // Запазваме URL
            }

            var photo = new MenuItem
            {
                RestaurantId = vM.RestaurantId,
                Photo = vM.Photo,
                ImageFile = vM.File
            };
            await this.repo.AddAsync(photo);
            return vM.RestaurantId;
        }
    }
}
