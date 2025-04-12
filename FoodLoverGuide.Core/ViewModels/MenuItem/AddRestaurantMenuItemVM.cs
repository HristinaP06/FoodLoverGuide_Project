using Microsoft.AspNetCore.Http;

namespace FoodLoverGuide.Core.ViewModels.MenuItem
{
    public class AddRestaurantMenuItemVM
    {
        public Guid RestaurantId { get; set; }

        public List<string> MenuPhotos { get; set; }

        public List<IFormFile> Files { get; set; }

        public string NextAction { get; set; }
    }
}
