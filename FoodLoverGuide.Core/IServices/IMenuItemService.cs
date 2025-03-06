using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodLoverGuide.Core.ViewModels.Restaurant;
using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Http;

namespace FoodLoverGuide.Core.IServices
{
    public interface IMenuItemService : IService<MenuItem>
    {
        Task<Guid> AddRestaurantPhoto(Guid restaurantId, IFormFile file, string url);
    }
}
