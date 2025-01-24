using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodLoverGuide.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantFeature> RestaurantFeatures { get; set; }
        public DbSet<RestaurantPhoto> RestaurantPhotos { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<WorkTimeSchedule> WorkTimeSchedules { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}
