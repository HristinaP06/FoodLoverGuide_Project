using FoodLoverGuide.DataAccess.Repository;
using FoodLoverGuide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLoverGuide.Core.Validators
{
    public class CategoryValidator
    {
        private static IRepository<Category> _repo;

        public static bool CategoryExist(Guid id)
        {
            if(_repo.Get(id) == null)
            {
                return false;
            }
            return true;
        }

        public static bool ValidateInput(string name)
        {
            if (name.Length == 0 || name.Length > 30)
            {
                return false;
            }
            return true;
        }


    }
}
