using Microsoft.AspNetCore.Http;

namespace FoodLoverGuide.Core.ViewModels.RestaurantPhoto;

public class EditPhotoRestaurantVM
{
    public Guid Id { get; set; }

    public Guid RestaurantId { get; set; }

    public string CurrentPhotoUrl { get; set; }

    public IFormFile NewFile { get; set; }

    public string NewUrl { get; set; }
}
