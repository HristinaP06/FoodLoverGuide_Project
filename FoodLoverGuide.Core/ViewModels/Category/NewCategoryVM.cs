using System.ComponentModel.DataAnnotations;

namespace FoodLoverGuide.Core.ViewModels.Category
{
    public class NewCategoryVM
    {
        [Required(ErrorMessage = "Полето {0} е задължително.")]
        [StringLength(300, ErrorMessage = "Полето {0} може да съдържа максимум {1} знака.")]
        [Display(Name = "Категория")]
        public string Name { get; set; }
    }
}
