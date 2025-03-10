using FoodLoverGuide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLoverGuide.Core.ViewModels.Restaurant
{
	public class AddFeatureToRestaurantVM
	{
        public Guid RestaurantId { get; set; }

		public List<Guid> SelectedFeaturesIds { get; set; } = new List<Guid>();

		public List<Models.Feature> FeaturesList { get; set; } = new List<Models.Feature>();
	}
}
