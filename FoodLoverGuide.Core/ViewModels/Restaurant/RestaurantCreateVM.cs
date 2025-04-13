using System.ComponentModel.DataAnnotations;

namespace FoodLoverGuide.Core.ViewModels.Restaurant
{
    public class RestaurantCreateVM
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Полето {0} е задължително.")]
        [StringLength(300, ErrorMessage = "Полето {0} може да съдържа максимум {1} знака.")]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Полето {0} е задължително.")]
        [StringLength(3000, ErrorMessage = "Полето {0} може да съдържа максимум {1} знака.")]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Полето {0} е задължително.")]
        [StringLength(300, ErrorMessage = "Полето {0} може да съдържа максимум {1} знака.")]
        [Display(Name = "Локация")]
        public string Location { get; set; }

        [Display(Name = "Телефон")]
        public string Telephone { get; set; }

        [EmailAddress(ErrorMessage = "Полето {0} не е валиден имейл адрес.")]
        [Display(Name = "Имейл")]
        public string Email { get; set; }

        [Display(Name = "Инстаграм страница")]
        public string Instagram { get; set; }

        [Display(Name = "Фейсбук страница")]
        public string Facebook { get; set; }

        [Display(Name = "Уебсайт")]
        public string WebSite { get; set; }

        [Display(Name = "Цени от")]
        public double? PriceRangeFrom { get; set; }

        [Display(Name = "Цени до")]
        public double? PriceRangeTo { get; set; }

        [Display(Name = "Вътрешен капацитет")]
        public int? IndoorCapacity { get; set; }

        [Display(Name = "Външен капацитет")]
        public int? OutdoorCapacity { get; set; }

        public string NextAction { get; set; }
    }
}
