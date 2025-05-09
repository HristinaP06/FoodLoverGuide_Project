﻿using System.ComponentModel.DataAnnotations;

namespace FoodLoverGuide.Models
{
    public class Feature
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(300)]
        public string Name { get; set; }

        public ICollection<RestaurantFeature> RestaurantsList = new List<RestaurantFeature>();
    }
}
