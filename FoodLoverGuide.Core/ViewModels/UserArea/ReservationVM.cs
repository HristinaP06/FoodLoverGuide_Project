using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLoverGuide.Core.ViewModels.UserArea
{
    public class ReservationVM
    {
        public Guid RestaurantId { get; set; }

        [Required]
        public DateTime SelectedDate { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Въведете брой възрастни.")]
        public int Adults { get; set; }

        [Range(0, 10, ErrorMessage = "Въведете брой деца.")]
        public int Children { get; set; }

        public List<DateTime> AvailableTimes { get; set; } = new List<DateTime>();
    }
}
