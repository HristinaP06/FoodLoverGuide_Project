using System.ComponentModel.DataAnnotations;

namespace FoodLoverGuide.Core.ViewModels.Feature
{
    public class NewFeatureVM
    {
        [Required(ErrorMessage = "Полето е задължително.")]
        [StringLength(20, ErrorMessage = "Името на категорията трябва да бъде между {2} и {1} символа.", MinimumLength = 5)]
        [Display(Name = "Характеристика")]
        public string Name { get; set; }
    }
}
