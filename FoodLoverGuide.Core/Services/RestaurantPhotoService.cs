using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.DataAccess.Repository;
using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace FoodLoverGuide.Core.Services
{
    public class RestaurantPhotoService : IRestaurantPhotoService
    {
        private readonly IRepository repo;
        private readonly CloudinaryService cloudinary; 

        public RestaurantPhotoService(IRepository repo, CloudinaryService cloudinary)
        {
            this.repo = repo;
            this.cloudinary = cloudinary;
        }
        public async Task Add(RestaurantPhoto entity)
        {
            await this.repo.AddAsync(entity);
        }

        public async Task Delete(Guid id)
        {
            await this.repo.DeleteAsync<RestaurantPhoto>(id);
        }

        public async Task<List<RestaurantPhoto>> Find(Expression<Func<RestaurantPhoto, bool>> filter)
        {
            return await this.repo.FindAsync(filter);
        }

        public IQueryable<RestaurantPhoto> GetAll()
        {
            return this.repo.GetAllAsync<RestaurantPhoto>();
        }

        public async Task<RestaurantPhoto> GetById(Guid id)
        {
            return await this.repo.GetByIdAsync<RestaurantPhoto>(id);
        }

        public async Task Update(RestaurantPhoto entity)
        {
            await this.repo.UpdateAsync(entity);
        }

        public async Task<Guid> AddRestaurantPhotoAsync(Guid restaurantId, IFormFile file, string url)
        {
            string uploadedImageUrl = null;

            if (file != null)
            {
                uploadedImageUrl = await this.cloudinary.UploadImageAsync(file);
            }
            else if (!string.IsNullOrEmpty(url))
            {
                uploadedImageUrl = url;
            }

            if (!string.IsNullOrEmpty(uploadedImageUrl))
            {
                var existingPhotos = await this.repo.FindAsync<RestaurantPhoto>(x => x.RestaurantId == restaurantId);
                int nextOrder = existingPhotos.Count > 0 ? existingPhotos.Max(p => p.Order) + 1 : 1;

                var photo = new RestaurantPhoto
                {
                    RestaurantId = restaurantId,
                    Photo = uploadedImageUrl,
                    ImageFile = file,
                    Order = nextOrder,
                };

                await this.repo.AddAsync(photo);
            }

            return restaurantId;
        }

        public async Task UpdateRestaurantPhotoAsync(Guid id, IFormFile newFile, string newUrl)
        {
            var existing = await this.repo.GetByIdAsync<RestaurantPhoto>(id);

            if (existing == null)
            {
                throw new Exception("Photo not found.");
            }

            string updatedPhotoUrl = null;

            if (newFile != null)
            {
                updatedPhotoUrl = await this.cloudinary.UploadImageAsync(newFile);
                existing.ImageFile = newFile;
            }
            else if (!string.IsNullOrEmpty(newUrl))
            {
                updatedPhotoUrl = newUrl;
                existing.ImageFile = null;
            }

            if (!string.IsNullOrEmpty(updatedPhotoUrl))
            {
                existing.Photo = updatedPhotoUrl;
                await this.repo.UpdateAsync(existing);
            }
        }
    }
}
