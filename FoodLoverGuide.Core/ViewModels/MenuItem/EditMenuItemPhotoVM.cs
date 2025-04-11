using Microsoft.AspNetCore.Http;

namespace FoodLoverGuide.Core.ViewModels.MenuItem
{
    public class EditMenuItemPhotoVM
    {
        public Guid Id { get; set; }

        public Guid RestaurantId { get; set; }

        public string CurrentMenuPhotoUrl { get; set; }

        public IFormFile NewFile { get; set; }

        public string NewUrl { get; set; }
    }
}
