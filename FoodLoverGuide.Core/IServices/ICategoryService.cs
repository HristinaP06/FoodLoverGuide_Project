using FoodLoverGuide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FoodLoverGuide.Core.IServices
{
    public interface ICategoryService
    {
        void Add(Category category);

        void Update(Category category);

        void Delete(Guid id);

        Category GetById(Guid id);

        List<Category> GetAll();

        Category GetRestaurantCategory(Guid restaurantId);

        List<Category> Find(Expression<Func<Category, bool>> filter);
    }
}
