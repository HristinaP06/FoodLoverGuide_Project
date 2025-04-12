namespace FoodLoverGuide.Core.ViewModels.MenuItem
{
    public class MenuItemsVM
    {
        public Guid RestaurantId { get; set; }

        public IList<FoodLoverGuide.Models.MenuItem> MenuItems { get; set; }
    }
}
