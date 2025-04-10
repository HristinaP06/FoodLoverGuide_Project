namespace FoodLoverGuide.Core.ViewModels.Restaurant
{
    public class AddFeatureToRestaurantVM
	{
        public Guid RestaurantId { get; set; }

		public List<Guid> SelectedFeaturesIds { get; set; } = new List<Guid>();

		public List<Models.Feature> FeaturesList { get; set; } = new List<Models.Feature>();

        public string NextAction { get; set; }
    }
}
