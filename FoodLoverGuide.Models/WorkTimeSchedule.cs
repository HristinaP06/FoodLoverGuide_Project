using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLoverGuide.Models
{
    public class WorkTimeSchedule
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Restaurant))]
        public Guid RestaurantId { get; set; }
        public Restaurant _Restaurant { get; set; }
        public DayOfWeek Date { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }

    }
}
