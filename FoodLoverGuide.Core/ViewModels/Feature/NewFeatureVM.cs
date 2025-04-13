using System.ComponentModel.DataAnnotations;

namespace FoodLoverGuide.Core.ViewModels.Feature
{
    public class NewFeatureVM
    {
        [Required(ErrorMessage = "Полето {0} е задължително.")]
        [StringLength(300, ErrorMessage = "Полето {0} може да съдържа максимум {1} знака.")]
        [Display(Name = "Характеристика")]
        public string Name { get; set; }
    }
}
