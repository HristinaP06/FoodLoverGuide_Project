using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodLoverGuide.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }

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
            builder.Entity<RestaurantCategories>().HasKey(cr => new { cr.CategoryId, cr.RestaurantId });

            builder.Entity<RestaurantCategories>()
                .HasOne(c => c.Category)
                .WithMany(r => r.RestaurantCategoriesList)
                .HasForeignKey(f => f.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<RestaurantCategories>()
                .HasOne(r => r.Restaurant)
                .WithMany(c =>c.RestaurantCategoriesList)
                .HasForeignKey(f => f.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<RestaurantFeature>().HasKey(rf => new {rf.FeatureId, rf.RestaurantId});

            builder.Entity<RestaurantFeature>()
                .HasOne(f => f.Features)
                .WithMany(r => r.RestaurantsList)
                .HasForeignKey(k => k.FeatureId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.Entity<RestaurantFeature>()
                .HasOne(r => r.Restaurants)
                .WithMany(f => f.Features)
                .HasForeignKey(k => k.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<MenuItem>()
                .HasOne(r=> r.Restaurant)
                .WithMany(m=> m.Menu)
                .HasForeignKey(f => f.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Rating>()
                .HasOne(res => res.Restaurant)
                .WithMany(r => r.RatingList)
                .HasForeignKey(f => f.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Review>()
                .HasOne(res => res.Restaurant)
                .WithMany(r => r.Reviews)
                .HasForeignKey(f => f.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<RestaurantPhoto>()
                .HasOne(r => r.Restaurant)
                .WithMany(p => p.Photos)
                .HasForeignKey(f => f.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<WorkTimeSchedule>()
                .HasOne(r => r.Restaurant)
                .WithMany(w => w.WorkTime)
                .HasForeignKey(f => f.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Reservation>()
                .HasOne(res => res.Restaurant)
                .WithMany(r => r.Reservation)
                .HasForeignKey(f => f.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Reservation>()
                .HasOne(u => u.User)
                .WithMany(r => r.Reservations)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Rating>()
                .HasOne(u => u.User)
                .WithMany(r => r.Ratings)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Review>()
                .HasOne(u => u.User)
                .WithMany(r => r.Reviews)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Category>().HasData
                (
                new Category
                {
                    Id = new Guid("4d8d411a-a288-4d94-a040-6d98126e7ed2"),
                    CategoryName = "Италианска кухня"
                },
                new Category
                {
                    Id= new Guid("7c9975a1-fd38-4495-93d2-38ae09c402c5"),
                    CategoryName = "Пицария"
                },
                new Category
                {
                    Id = new Guid("2f2a0aa4-ef02-4ffa-ad36-f6abcb5cad3e"),
                    CategoryName = "Бързо хранене"
                },
                new Category
                {
                    Id = new Guid("a3730467-ed8f-47d3-903e-cf6cb8aea583"),
                    CategoryName = "Гръцка кухня"
                },
                new Category
                {
                    Id = new Guid("0068eb45-f381-4a34-8385-cec0e483df37"),
                    CategoryName = "Българска кухня"
                },
                new Category
                {
                    Id = new Guid("3ce78111-d73b-431b-a52b-96b226fed723"),
                    CategoryName = "Турска кухня"
                },
                new Category
                {
                    Id = new Guid("04ae13cb-8755-4f52-a6b0-53a8e05c3200"),
                    CategoryName = "Азиатска кухня"
                },
                new Category
                {
                    Id = new Guid("e12d1204-3592-4caa-bd6b-3d5e3aca32d6"),
                    CategoryName = "Морска храна"
                },
                new Category
                {
                    Id = new Guid("1b0f88fb-a91d-446e-8f5e-7a8602d2b901"),
                    CategoryName = "Бистро"
                }
                );

            builder.Entity<Feature>().HasData(
                new Feature
                {
                    Id = new Guid("a43a3f1e-02d6-45a9-86a9-06cd2522a9cc"),
                    Name = "Външен детски кът"
                },
                new Feature
                {
                    Id = new Guid("55b7cb27-7913-474a-bf44-5ddff365f959"),
                    Name = "Градина"
                },
                new Feature
                {
                    Id = new Guid("977f158f-77d1-420a-9fcf-6fa6ea75bb38"),
                    Name = "Място за пушачи"
                },
                new Feature
                {
                    Id = new Guid("5c9469f1-1b5c-4089-91e9-f8241fa4a805"),
                    Name = "Вътрешен детски кът"
                },
                new Feature
                {
                    Id = new Guid("63d4971a-893f-4271-8412-52a924f99905"),
                    Name = "Интерннет"
                },
                new Feature
                {
                    Id = new Guid("9a4bf8ac-700f-4348-a70d-c91b992e48b8"),
                    Name = "Паркинг"
                },
                new Feature
                {
                    Id = new Guid("4555dc2e-7693-4544-92c4-9ab807373a59"),
                    Name = "Достъпност за инвалиди"
                },
                new Feature
                {
                    Id = new Guid("62f341ac-7dd5-4339-88e6-77c26954cb9a"),
                    Name = "Доставка"
                },
                new Feature
                {
                    Id = new Guid("d68c6e75-bf22-4fd2-bf84-dd66a4073057"),
                    Name = "Възможност за плащане с карта"
                }
                );
            
            builder.Entity<Restaurant>().HasData(
                new Restaurant
                {
                    Id = new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b"),
                    Name = "Marcon Italian Cuisine",
                    Description = "Трябва да се посети не само Исторически музей Искра, но и Marcon Italian Cuisine. Посетителите посочват, че е добре да отидете тук за италианска храна. Този ресторант е за препоръчване за добре приготвени пици, паста и салати. Както твърдят много рецензенти, лимонадата е наистина страхотна.Уютната атмосфера на Marcon Italian Cuisine дава  възможност на гостите да релаксират след тежък работен ден. Приятният персонал работи усилено, остава позитивен и прави това място страхотно. Обслужването на това място е нещо, което човек може да нарече бързо. Ще харесате справедливи цени.",
                    Location = "ул. 'Любен Каравелов' 3, Казанлък",
                    Telephone = "0883530101",
                    Email = "marconpizza@gmail.com",
                    WebSite = "",
                    Facebook = "Marcon Italian Cuisine",
                    Instagram = "marcon_italian_cuisine",
                    PriceRangeFrom = 18,
                    PriceRangeTo = 45,
                    IndoorCapacity = 60,
                    OutdoorCapacity = 60
                },
                new Restaurant
                {
                    Id = new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342"),
                    Name = "Meraki Urban Gastro Lounge",
                    Description = "Исторически музей Искра може да бъде на вашия маршрут по подразбиране, съветът на клиентите е да посетите този ресторант." +
                    " Потопете се в прекрасната гръцка и италианска кухня на това място. Заслужава си да посетите Meraki Urban Gastro Lounge за добри бургери," +
                    " салати капрезе и свинско. Тук можете да поръчате вкусно вино. Уютната атмосфера на това място кара гостите да се чувстват спокойни и да си" +
                    " прекарват приятно. Успехът на това място не би бил възможен без любезния персонал. Доброто обслужване е нещо, което посетителите отбелязват " +
                    "в отзивите си. В този ресторант се очакват адекватни цени.",
                    Location = "ул. 'Чудомир' 6, Казанлък",
                    Telephone = "0898909098",
                    Email = "",
                    WebSite = "",
                    Facebook = "Meraki Urban Gastro Lounge ",
                    Instagram = "meraki_alldayfoodexperience",
                    PriceRangeFrom = 18,
                    PriceRangeTo = 45,
                    IndoorCapacity = 30,
                    OutdoorCapacity = 30
                },
                new Restaurant
                {
                    Id = new Guid("8670fecf-265e-4743-be6a-6477389cc15e"),
                    Name = "Ресторант Делта",
                    Description = "Гостите казват, че тук харесват италианската и турската кухня." +
                    " Ресторант Делта осигурява доставка на храна за удобство на своите клиенти. " +
                    "Внимателният персонал работи усилено, остава позитивен и прави това място страхотно." +
                    " Доброто обслужване показва високо ниво на качество на това място. Според мненията на рецензентите цените са средни. Със сигурност ще оцените спокойната атмосфера",
                    Location = "ул. 'Бачо Киро' 2, Казанлък",
                    Telephone = "0888655655",
                    Email = "delta.restaurant.pizza@gmail.com",
                    WebSite = "",
                    Facebook = "Ресторант Делта",
                    Instagram = "delta.restaurant.pizza",
                    PriceRangeFrom = 18,
                    PriceRangeTo = 45,
                    IndoorCapacity = 100,
                    OutdoorCapacity = 0
                }
                );
            
            //Marcon - relation tables

            builder.Entity<RestaurantCategories>().HasData(
                new RestaurantCategories
                {
                    CategoryId = new Guid("4d8d411a-a288-4d94-a040-6d98126e7ed2"),
                    RestaurantId = new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b"),
                });

            builder.Entity<RestaurantFeature>().HasData(
                new RestaurantFeature
                {
                    FeatureId = new Guid("55b7cb27-7913-474a-bf44-5ddff365f959"),
                    RestaurantId = new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b")
                },
                new RestaurantFeature
                {
                    FeatureId = new Guid("977f158f-77d1-420a-9fcf-6fa6ea75bb38"),
                    RestaurantId = new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b")
                },
                new RestaurantFeature
                {
                    FeatureId = new Guid("63d4971a-893f-4271-8412-52a924f99905"),
                    RestaurantId = new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b")
                },
                new RestaurantFeature
                {
                    FeatureId = new Guid("9a4bf8ac-700f-4348-a70d-c91b992e48b8"),
                    RestaurantId = new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b")
                },
                new RestaurantFeature
                {
                    FeatureId = new Guid("4555dc2e-7693-4544-92c4-9ab807373a59"),
                    RestaurantId = new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b")
                },
                new RestaurantFeature
                {
                    FeatureId = new Guid("62f341ac-7dd5-4339-88e6-77c26954cb9a"),
                    RestaurantId = new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b")
                },
                new RestaurantFeature
                {
                    FeatureId = new Guid("d68c6e75-bf22-4fd2-bf84-dd66a4073057"),
                    RestaurantId = new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b")
                });

            builder.Entity<WorkTimeSchedule>().HasData(
                new WorkTimeSchedule
                {
                    Id = new Guid("4e2bbed5-ba4b-44b6-b16a-86de98a63ce0"),
                    RestaurantId = new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b"),
                    Day = DayOfWeek.Monday,
                    OpeningTime = new TimeSpan(11,30,00),
                    ClosingTime = new TimeSpan(23,30,00)
                },
                new WorkTimeSchedule
                {
                    Id = new Guid("dfe91a02-404b-4d36-8537-b1b82fe28d43"),
                    RestaurantId = new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b"),
                    Day = DayOfWeek.Tuesday,
                    OpeningTime = new TimeSpan(11, 30, 00),
                    ClosingTime = new TimeSpan(23, 30, 00)
                },
                new WorkTimeSchedule
                {
                    Id = new Guid("64bb2a3b-585c-48dd-9e0b-216ce8524a8c"),
                    RestaurantId = new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b"),
                    Day = DayOfWeek.Wednesday,
                    OpeningTime = new TimeSpan(11, 30, 00),
                    ClosingTime = new TimeSpan(23, 30, 00)
                },
                new WorkTimeSchedule
                {
                    Id = new Guid("53985eee-46ca-44e1-b457-4c3fc73e60c2"),
                    RestaurantId = new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b"),
                    Day = DayOfWeek.Thursday,
                    OpeningTime = new TimeSpan(11, 30, 00),
                    ClosingTime = new TimeSpan(23, 30, 00)
                },
                new WorkTimeSchedule
                {
                    Id = new Guid("16e600d3-5d1d-4f6a-afe0-2a8994f647df"),
                    RestaurantId = new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b"),
                    Day = DayOfWeek.Friday,
                    OpeningTime = new TimeSpan(11, 30, 00),
                    ClosingTime = new TimeSpan(23, 30, 00)
                },
                new WorkTimeSchedule
                {
                    Id = new Guid("f07de646-e32b-4e34-9031-a61d1f5d3437"),
                    RestaurantId = new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b"),
                    Day = DayOfWeek.Saturday,
                    OpeningTime = new TimeSpan(11, 30, 00),
                    ClosingTime = new TimeSpan(23, 30, 00)
                },
                new WorkTimeSchedule
                {
                    Id = new Guid("6355f560-db8e-43e5-b36b-1b282950f841"),
                    RestaurantId = new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b"),
                    Day = DayOfWeek.Sunday,
                    OpeningTime = new TimeSpan(12, 00, 00),
                    ClosingTime = new TimeSpan(17, 30, 00)
                });

            builder.Entity<Rating>().HasData(
                new Rating
                {
                    Id = new Guid("2e2038e6-181b-4808-8184-c38afb5a2ddc"),
                    _Rating = 5,
                    RestaurantId = new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b"),
                    UserId = new Guid("bce98f2f-6ebc-4024-ab7b-b3c1245bb6e3").ToString()
                });

            //Meraki - relation tables

            builder.Entity<RestaurantCategories>().HasData(
                new RestaurantCategories
                {
                    CategoryId = new Guid("4d8d411a-a288-4d94-a040-6d98126e7ed2"),
                    RestaurantId = new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342")
                },
                new RestaurantCategories
                {
                    CategoryId = new Guid("a3730467-ed8f-47d3-903e-cf6cb8aea583"),
                    RestaurantId = new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342")
                },
                new RestaurantCategories
                {
                    CategoryId = new Guid("0068eb45-f381-4a34-8385-cec0e483df37"),
                    RestaurantId = new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342")
                });

            builder.Entity<RestaurantFeature>().HasData(
              new RestaurantFeature
              {
                  FeatureId = new Guid("55b7cb27-7913-474a-bf44-5ddff365f959"),
                  RestaurantId = new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342")
              },
              new RestaurantFeature
              {

                  FeatureId = new Guid("4555dc2e-7693-4544-92c4-9ab807373a59"),
                  RestaurantId = new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342")
              },
              new RestaurantFeature
              {
                  FeatureId = new Guid("63d4971a-893f-4271-8412-52a924f99905"),
                  RestaurantId = new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342")
              },
              new RestaurantFeature
              {
                  FeatureId = new Guid("62f341ac-7dd5-4339-88e6-77c26954cb9a"),
                  RestaurantId = new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342")
              },
              new RestaurantFeature
              {
                  FeatureId = new Guid("d68c6e75-bf22-4fd2-bf84-dd66a4073057"),
                  RestaurantId = new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342")
              });

            builder.Entity<WorkTimeSchedule>().HasData(
                new WorkTimeSchedule
                {
                    Id = new Guid("3c519e19-9696-46a4-be31-1c42d886e1e5"),
                    RestaurantId = new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342"),
                    Day = DayOfWeek.Monday,
                    IsClosed = false,
                },
                new WorkTimeSchedule
                {
                    Id = new Guid("acf0156c-7576-42d6-9b11-984d313aea51"),
                    RestaurantId = new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342"),
                    Day = DayOfWeek.Tuesday,
                    OpeningTime = new TimeSpan(8,30,00),
                    ClosingTime = new TimeSpan(23,00,00)
                },
                new WorkTimeSchedule
                {
                    Id = new Guid("c0790a6d-08c0-4470-a533-f19f40013672"),
                    RestaurantId = new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342"),
                    Day = DayOfWeek.Wednesday,
                    OpeningTime = new TimeSpan(8,30,00),
                    ClosingTime = new TimeSpan(23,00,00)
                },
                new WorkTimeSchedule
                {
                    Id = new Guid("010383fe-ebc4-48e2-b98e-2182e24bce31"),
                    RestaurantId = new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342"),
                    Day = DayOfWeek.Thursday,
                    OpeningTime = new TimeSpan(8,30,00),
                    ClosingTime = new TimeSpan(23,00,00)
                },
                new WorkTimeSchedule
                {
                    Id = new Guid("813f0637-9a00-4612-b5a4-3b2aee6ec6ac"),
                    RestaurantId = new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342"),
                    Day = DayOfWeek.Friday,
                    OpeningTime = new TimeSpan(8,30,00),
                    ClosingTime = new TimeSpan(23,00,00)
                },
                new WorkTimeSchedule
                {
                    Id = new Guid("b62049ab-ee45-4415-aa0c-690dd5b50ce5"),
                    RestaurantId = new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342"),
                    Day = DayOfWeek.Saturday,
                    OpeningTime = new TimeSpan(8,30,00),
                    ClosingTime = new TimeSpan(23,00,00)
                },
                new WorkTimeSchedule
                {
                    Id = new Guid("93255465-e52f-421c-b0df-ea6ef6696832"),
                    RestaurantId = new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342"),
                    Day = DayOfWeek.Sunday,
                    IsClosed = false,
                });

            builder.Entity<Rating>().HasData(
               new Rating
               {
                   Id = new Guid("cdbded6f-d5d8-408b-a87c-b66f564e47af"),
                   _Rating = 5,
                   RestaurantId = new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342"),
                   UserId = new Guid("bce98f2f-6ebc-4024-ab7b-b3c1245bb6e3").ToString()
               });

            //Restaurant Delta - relation tables

            builder.Entity<RestaurantCategories>().HasData(
                new RestaurantCategories
                {
                    CategoryId = new Guid("3ce78111-d73b-431b-a52b-96b226fed723"),
                    RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e")
                },
                new RestaurantCategories
                {
                    CategoryId = new Guid("0068eb45-f381-4a34-8385-cec0e483df37"),
                    RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e")
                }
                );

            builder.Entity<RestaurantFeature>().HasData(
                new RestaurantFeature
                {
                    FeatureId = new Guid("977f158f-77d1-420a-9fcf-6fa6ea75bb38"),
                    RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e")
                },
                new RestaurantFeature
                {
                    FeatureId = new Guid("63d4971a-893f-4271-8412-52a924f99905"),
                    RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e")
                },
                new RestaurantFeature
                {
                    FeatureId = new Guid("9a4bf8ac-700f-4348-a70d-c91b992e48b8"),
                    RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e")
                },
                new RestaurantFeature
                {
                    FeatureId = new Guid("4555dc2e-7693-4544-92c4-9ab807373a59"),
                    RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e")
                },
                new RestaurantFeature
                {
                    FeatureId = new Guid("62f341ac-7dd5-4339-88e6-77c26954cb9a"),
                    RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e")
                },
                new RestaurantFeature
                {
                    FeatureId = new Guid("d68c6e75-bf22-4fd2-bf84-dd66a4073057"),
                    RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e")
                });

            builder.Entity<WorkTimeSchedule>().HasData(
                new WorkTimeSchedule
                {
                    Id = new Guid("887e6c1a-0629-4ac2-b2fa-0370fbfbf763"),
                    RestaurantId= new Guid("8670fecf-265e-4743-be6a-6477389cc15e"),
                    Day = DayOfWeek.Monday,
                    OpeningTime = new TimeSpan(6,00,00),
                    ClosingTime = new TimeSpan(22,30,00)
                },
                new WorkTimeSchedule
                {
                    Id = new Guid("174bc1fe-a957-41d7-8a38-afb7c1c9a340"),
                    RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e"),
                    Day = DayOfWeek.Tuesday,
                    OpeningTime = new TimeSpan(6, 00, 00),
                    ClosingTime = new TimeSpan(22, 30, 00)
                },
                new WorkTimeSchedule
                {
                    Id = new Guid("be5b1bad-fd82-4850-9646-1d8de29532fa"),
                    RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e"),
                    Day = DayOfWeek.Wednesday,
                    OpeningTime = new TimeSpan(6, 00, 00),
                    ClosingTime = new TimeSpan(22, 30, 00)
                },
                new WorkTimeSchedule
                {
                    Id = new Guid("7cf04ef9-fd79-40f2-935a-12b0675a6307"),
                    RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e"),
                    Day = DayOfWeek.Thursday,
                    OpeningTime = new TimeSpan(6, 00, 00),
                    ClosingTime = new TimeSpan(22, 30, 00)
                },
                new WorkTimeSchedule
                {
                    Id = new Guid("898454a9-3569-4827-ae31-a6919a56351d"),
                    RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e"),
                    Day = DayOfWeek.Friday,
                    OpeningTime = new TimeSpan(6, 00, 00),
                    ClosingTime = new TimeSpan(22, 30, 00)
                },
                new WorkTimeSchedule
                {
                    Id = new Guid("357fa35e-6b3c-4c1d-bdfe-2951e0fc3547"),
                    RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e"),
                    Day = DayOfWeek.Saturday,
                    OpeningTime = new TimeSpan(6, 00, 00),
                    ClosingTime = new TimeSpan(22, 30, 00)
                },
                new WorkTimeSchedule
                {
                    Id = new Guid("fbf95d72-3540-414a-94be-0d126b97cceb"),
                    RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e"),
                    Day = DayOfWeek.Sunday,
                    OpeningTime = new TimeSpan(6, 00, 00),
                    ClosingTime = new TimeSpan(22, 30, 00)
                });

            builder.Entity<Rating>().HasData(
               new Rating
               {
                   Id = new Guid("84e5975b-ad32-426f-93d5-03fa0545e802"),
                   _Rating = 5,
                   RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e"),
                   UserId = new Guid("bce98f2f-6ebc-4024-ab7b-b3c1245bb6e3").ToString()
               });

            base.OnModelCreating(builder);
        }
    }
}
