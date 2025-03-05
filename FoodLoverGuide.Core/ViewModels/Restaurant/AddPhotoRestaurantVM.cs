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

        public string Photo { get; set; }

        public IFormFile File { get; set; }
    }
}
