using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLoverGuide.Core.ViewModels.Restaurant
{
    public class AddWorkTimeScheduleToRestaurantVM
    {
        public Guid RestaurantId { get; set; }

        public Dictionary<DayOfWeek, List<TimeSpan>> WorkSchedule { get; set; }

    }
}
