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
                    Description = "Трябва да се посети не само Исторически музей Искра, но и Marcon Italian Cuisine." +
                    " Посетителите посочват, че е добре да отидете тук за италианска храна. Този ресторант е за препоръчване за добре приготвени пици, " +
                    "паста и салати. Както твърдят много рецензенти, лимонадата е наистина страхотна.Уютната атмосфера на Marcon Italian Cuisine дава " +
                    "възможност на гостите да релаксират след тежък работен ден. Приятният персонал работи усилено, остава позитивен и прави това място страхотно. " +
                    "Обслужването на това място е нещо, което човек може да нарече бързо. Ще харесате справедливи цени.",
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
                    Id = new Guid("e17f320c-0a7a-4bec-ae33-f736b57391a6"),
                    Name = "Bellezza - Bar & Grill",
                    Description = "Този бар ви осигурява вкусна храна и място за почивка след дълга разходка из Исторически музей Искра. " +
                    "Яденето на перфектно сготвени спагети карбонара, пиле и салати е това, което редица гости препоръчват. " +
                    "Свежата атмосфера на това място позволява на клиентите да се отпуснат след тежък работен ден. Симпатичният персонал работи усилено, " +
                    "остава позитивен и прави това място страхотно. Готиното обслужване е голям плюс на това място." +
                    " Повечето рецензенти споменават, че цените са разумни за това, което получавате.",
                    Location = "ул. 'Старозагорска' 2А, Казанлък",
                    Telephone = "0899322690",
                    Email = "",
                    WebSite = "",
                    Facebook = "Bellezza Bar & Grill",
                    Instagram = "bellezzabargrill",
                    PriceRangeFrom = 10,
                    PriceRangeTo = 30,
                    IndoorCapacity = 100,
                    OutdoorCapacity = 30
                },
                new Restaurant
                {
                    Id = new Guid("64bf4496-2ffe-41f9-b6e1-8cb6a167b001"),
                    Name = "Bellezza",
                    Description = "Ако дъждът ви изненада по време на разходката около Национален парк-музей Шипка-Бузлужа, отбийте се в този ресторант. " +
                    "Много хора казват, че тук сервитьорите сервират добра пица, пилешки крилца и свинско. Не пропускайте възможността да поръчате вкусна бира." +
                    " Тук можете да пиете страхотно кафе. Лесно е да намерите Bellezza поради удобното местоположение. " +
                    "Компетентният персонал работи усилено, остава позитивен и прави това място страхотно. Приятното обслужване е голямо предимство на това място." +
                    " От гледна точка на гостите цените са атрактивни. Със сигурност ще се насладите на приятната атмосфера.",
                    Location = "ул. 'Отец Паисий Хилендарски' 2А, Казанлък",
                    Telephone = "0894521260",
                    Email = "bellezzacafebar@gmail.com",
                    Facebook = "Bellezza Cafe Bar",
                    Instagram = "",
                    WebSite = "",
                    PriceRangeFrom = 18,
                    PriceRangeTo = 45,
                    IndoorCapacity = 60,
                    OutdoorCapacity = 20
                },
                new Restaurant
                {
                    Id = new Guid("68bde11b-41a4-4f72-8dd1-f9b1b2a16eed"),
                    Name = "Пицария Искра",
                    Description = " Да опитате перфектно приготвена пица и хубави салати е наистина добра идея." +
                    " Удобната локация на Pizza Iskra / Пицария Искра я прави лесно достъпна дори и в пиковите часове. " +
                    "Повечето посетители твърдят, че служителите са гостоприемни. Ако искате да изпитате страхотно обслужване, трябва да посетите това място." +
                    " Цените са адекватни тук. Може да обърнете внимание на приятната атмосфера.",
                    Location = "ул. 'Искра' 18, Казанлък",
                    Telephone = "043159901",
                    Email = "",
                    WebSite = "",
                    Facebook = "Пицария ИСКРА",
                    Instagram = "pizzariaiskra",
                    PriceRangeFrom = 18,
                    PriceRangeTo = 45,
                    IndoorCapacity = 40,
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
                },
                new Restaurant
                {
                    Id = new Guid("fdd8e014-aa7c-4d36-b83e-d00750c552ad"),
                    Name = "Ресторант Лагуна",
                    Description = "След като разгледахте Исторически музей Искра, време е да си починете в този ресторант. " +
                    "Заповядайте в ресторант Лагуна за почивка и опитайте перфектно приготвено американско филе, риба и салати." +
                    " Време е да дегустирате вкусно вино.Топлата атмосфера на това място кара гостите да се чувстват спокойни и да си прекарват приятно. " +
                    "Готиният персонал демонстрира високо ниво на гостоприемство на това място. " +
                    "Невероятното обслужване е нещо, което хората отбелязват в отзивите си. Този ресторант ви предлага добри цени за вкусни ястия.",
                    Location = "бул. 'Никола Петков' 37А, Казанлък",
                    Telephone = "043176767",
                    Email = "",
                    WebSite = "",
                    Facebook = "Restorant Laguna",
                    Instagram = "",
                    PriceRangeFrom = 18,
                    PriceRangeTo = 45,
                    IndoorCapacity = 100,
                    OutdoorCapacity = 100
                },
                new Restaurant
                {
                    Id = new Guid("39fbf8da-7b50-4f65-b3c8-3601e9adcd33"),
                    Name = "Ресторант Опела",
                    Description = "Минавайки покрай Музея на розите, посетете този ресторант. Потопете се в прекрасната българска кухня на това място. " +
                    "Топлата атмосфера на Ресторант Опела кара клиентите да се чувстват спокойни и да си прекарват приятно. " +
                    "Членовете на персонала са креативни и това прави това място толкова добро. Доброто обслужване е нещо, което клиентите харесват тук. " +
                    "Според мненията на рецензентите, цените са справедливи.",
                    Location = "ул. 'Сергей Румянцев' 1А, Казанлък",
                    Telephone = "043170299",
                    Email = "",
                    WebSite = "",
                    Facebook = "",
                    Instagram = "restorant_opela",
                    PriceRangeFrom = 20,
                    PriceRangeTo = 30,
                    IndoorCapacity = 75,
                    OutdoorCapacity = 75
                },
                new Restaurant
                {
                    Id = new Guid("da5d839b-a421-430b-91df-3bbf866ed69c"),
                    Name = "Ko Shi Yam",
                    Description = "Посетете това място и опитайте китайската кухня. Доставката на храна е голям плюс на този ресторант." +
                    " Успехът на Ko Shi Yam би бил невъзможен без опитния персонал. Доброто обслужване е нещо, което гостите отбелязват в отзивите си." +
                    " Ще плащате ниски цени за ястия. През повечето време уютната атмосфера се намира тук.",
                    Location = "ул. 'Цар Петър' 29, Казанлък",
                    Telephone = "043181320",
                    Email = "",
                    WebSite = "ko-shi-iam.com",
                    Facebook = "Ко Ши Ям (Китайски ресторант) ",
                    Instagram = "koshiqmkz",
                    PriceRangeFrom = 15,
                    PriceRangeTo = 30,
                    IndoorCapacity = 30,
                    OutdoorCapacity = 30
                },
                new Restaurant
                {
                    Id = new Guid("4f3f68d3-3d1b-4dd1-8c7e-3686ee3bdc35"),
                    Name = "",
                    Description = "Елате в този ресторант, за да вечеряте, ако сте гладни, след като сте разгледали Музея на розите. Ресторант \"Сезони\" " +
                    "предлага добро кафе сред своите напитки. Уютната атмосфера на това място кара гостите да се чувстват спокойни и да си прекарват приятно." +
                    " Казват, че сервитьорът тук е весел. Страхотното обслужване демонстрира високо ниво на качество в този ресторант. " +
                    "Много рецензенти отбелязват, че цените са демократични за това, което получавате.",
                    Location = "ул. 'Кадемлия' 31, Казанлък",
                    Telephone = "0877300166",
                    Email = "bistrosezoni@abv.bg",
                    WebSite = "",
                    Facebook = "Sezoni",
                    Instagram = "",
                    PriceRangeFrom = 10,
                    PriceRangeTo = 20,
                    IndoorCapacity = 60,
                    OutdoorCapacity = 60
                }
                );



            base.OnModelCreating(builder);
        }
    }
}
