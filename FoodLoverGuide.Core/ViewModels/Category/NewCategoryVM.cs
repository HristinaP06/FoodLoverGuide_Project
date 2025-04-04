﻿using System.ComponentModel.DataAnnotations;

namespace FoodLoverGuide.Core.ViewModels.Category
{
    public class NewCategoryVM
    {
        [Required(ErrorMessage = "Полето е задължително.")]
        [StringLength(20, ErrorMessage = "Името на категорията трябва да бъде между {2} и {1} символа.", MinimumLength = 5)]
        [Display(Name = "Категория")]
        public string Name { get; set; }
    }
}
