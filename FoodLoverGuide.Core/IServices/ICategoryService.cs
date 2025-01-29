using FoodLoverGuide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FoodLoverGuide.Core.IServices
{
    public interface ICategoryService : IService<Category>
    {
        Category GetRestaurantCategory(Guid restaurantId);
    }
}
