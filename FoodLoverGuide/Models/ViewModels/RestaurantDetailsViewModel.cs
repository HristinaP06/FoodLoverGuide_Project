using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodLoverGuide.Models.ViewModels
{
    public class RestaurantDetailsViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }

        public string? Telephone { get; set; }
        public string? Email { get; set; }

        public string? Media { get; set; }

        public ICollection<SocialMedia> SocialMedias { get; set; }

        public List<Guid>? SelectedCategoriesId { get; set; } = new List<Guid>();
        public List<SelectListItem>? Categories { get; set; } = new List<SelectListItem>();

        public List<Guid>? SelectedFeaturesId { get; set; } = new List<Guid>();
        public List<SelectListItem>? Features { get; set; } = new List<SelectListItem>();

        public double? PriceRangeFrom { get; set; }
        public double? PriceRangeTo { get; set; }

        public int? IndoorCapacity { get; set; }
        public int? OutdoorCapacity { get; set; }

        public DayOfWeek Date { get; set; }

        public TimeSpan Start { get; set; }

        public TimeSpan End { get; set; }
        public ICollection<WorkTimeSchedule> WorkTime { get; set; }
    }
}
