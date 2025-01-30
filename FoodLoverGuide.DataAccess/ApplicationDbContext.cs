using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodLoverGuide.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<User>
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

        public DbSet<User> Users {  get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<RestaurantCategories>().HasKey(cr => new { cr.CategoryId, cr.RestaurantId });

            builder.Entity<RestaurantCategories>()
                .HasOne(c => c.Category)
                .WithMany(r => r.RestaurantCategoriesList)
                .HasForeignKey(f => f.CategoryId);

            builder.Entity<RestaurantCategories>()
                .HasOne(r => r.Restaurant)
                .WithMany(c =>c.RestaurantCategoriesList)
                .HasForeignKey(f => f.RestaurantId);

            builder.Entity<Contact>()
                .HasOne(c => c.Restaurant)
                .WithOne(r => r.RestaurantContacts)
                .HasForeignKey<Contact>(f => f.RestaurantId);

            builder.Entity<SocialMedia>()
               .HasOne(s => s.Contact)
               .WithMany(c => c.SocialMedia)
               .HasForeignKey(f => f.ContactId);

            builder.Entity<RestaurantFeature>().HasKey(rf => new {rf.FeatureId, rf.RestaurantId});

            builder.Entity<RestaurantFeature>()
                .HasOne(f => f.Features)
                .WithMany(r => r.RestaurantsList)
                .HasForeignKey(k => k.FeatureId);
            
            builder.Entity<RestaurantFeature>()
                .HasOne(r => r.Restaurants)
                .WithMany(f => f.Features)
                .HasForeignKey(k => k.RestaurantId);

            builder.Entity<MenuItem>()
                .HasOne(r=> r.Restaurant)
                .WithMany(m=> m.Menu)
                .HasForeignKey(f => f.RestaurantId);

            builder.Entity<Rating>()
                .HasOne(res => res.Restaurant)
                .WithMany(r => r.RatingList)
                .HasForeignKey(f => f.RestaurantId);

            builder.Entity<Review>()
                .HasOne(res => res.Restaurant)
                .WithMany(r => r.Reviews)
                .HasForeignKey(f => f.RestaurantId);

            builder.Entity<RestaurantPhoto>()
                .HasOne(r => r.Restaurant)
                .WithMany(p => p.Photos)
                .HasForeignKey(f => f.RestaurantId);

            builder.Entity<WorkTimeSchedule>()
                .HasOne(r => r.Restaurant)
                .WithMany(w => w.WorkTime)
                .HasForeignKey(f => f.RestaurantId);

            builder.Entity<Reservation>()
                .HasOne(res => res.Restaurant)
                .WithMany(r => r.Reservation)
                .HasForeignKey(f => f.RestaurantId);

            builder.Entity<Reservation>()
                .HasOne(u => u.User)
                .WithMany(r => r.Reservations)
                .HasForeignKey(f => f.UserId);

            builder.Entity<Rating>()
                .HasOne(u => u.User)
                .WithMany(r => r.Ratings)
                .HasForeignKey(f => f.UserId);

            builder.Entity<Review>()
                .HasOne(u => u.User)
                .WithMany(r => r.Reviews)
                .HasForeignKey(f => f.UserId);

            base.OnModelCreating(builder);
        }
    }
}
