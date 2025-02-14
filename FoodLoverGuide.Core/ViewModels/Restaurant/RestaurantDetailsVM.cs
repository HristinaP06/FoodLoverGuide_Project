namespace FoodLoverGuide.Core.ViewModels.Restaurant
{
    public class RestaurantDetailsVM
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string? Telephone { get; set; }

        public string? Email { get; set; }

        public string? Instagram { get; set; }

        public string? Facebook { get; set; }

        public string? WebSite { get; set; }

        public double? PriceRangeFrom { get; set; }

        public double? PriceRangeTo { get; set; }

        public int? IndoorCapacity { get; set; }

        public int? OutdoorCapacity { get; set; }
    }
}
