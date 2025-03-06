using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FoodLoverGuide.Core.ViewModels.Restaurant
{
    public class AddPhotoRestaurantVM
    {
        public Guid RestaurantId { get; set; }

        public List<string> Photos { get; set; }

        public List<IFormFile> Files { get; set; }
    }
}
