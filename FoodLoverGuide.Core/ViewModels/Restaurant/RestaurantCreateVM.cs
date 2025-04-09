namespace FoodLoverGuide.Core.ViewModels.Restaurant
{
    public class RestaurantCreateVM
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public string Instagram { get; set; }

        public string Facebook { get; set; }

        public string WebSite { get; set; }

        public double? PriceRangeFrom { get; set; }

        public double? PriceRangeTo { get; set; }

        public int? IndoorCapacity { get; set; }

        public int? OutdoorCapacity { get; set; }

        public string NextAction { get; set; }
    }
}
