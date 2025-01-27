using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Core.Validators;
using FoodLoverGuide.DataAccess.Repository;
using FoodLoverGuide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FoodLoverGuide.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _repo;

        public CategoryService(IRepository<Category> repo)
        {
            _repo = repo;
        }

        public void Add(Category category)
        {
            if(CategoryValidator.ValidateInput(category.CategoryName))
            {
                _repo.Add(category);
            }
            else
            {
                throw new ArgumentException("Invalid name or already existing category!");
            }
        }

        public void Delete(Guid id)
        {
            if (CategoryValidator.CategoryExist(id))
            {
                _repo.Delete(id);
            }
            else
            {
                throw new ArgumentException("This category does not exist!");
            }
        }

        public List<Category> Find(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public Category GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Category GetRestaurantCategory(Guid restaurantId)
        {
            throw new NotImplementedException();
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
