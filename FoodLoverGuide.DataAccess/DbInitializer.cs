﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Identity;
using static System.Formats.Asn1.AsnWriter;

namespace FoodLoverGuide.DataAccess
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(ApplicationDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();

            var roles = new List<string> { "Admin", "User" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            //Ensure Admin User Exists
            string adminEmail = "admin@gmail.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                User user = new User
                {
                    UserName = "Admin",
                    FirstName = "Admin",
                    LastName = "Admin",
                    Email = adminEmail,
                    Age = 20,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(user, "@dmIn25");
                await userManager.AddToRoleAsync(user, "Admin");
            }

            string userEmail = "tina@gmail.com";
            var userUser = await userManager.FindByEmailAsync(userEmail);
            if (userUser == null)
            {
                var user1 = new User
                {
                    UserName = "Tina",
                    FirstName = "Hristina",
                    LastName = "Pirinova",
                    Email = userEmail,
                    Age = 19,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(user1, "tiN@0641");
                await userManager.AddToRoleAsync(user1, "User");
            }

            //Categories
            if (!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category { Id = new Guid("4d8d411a-a288-4d94-a040-6d98126e7ed2"), CategoryName = "Италианска кухня" },
                    new Category { Id = new Guid("7c9975a1-fd38-4495-93d2-38ae09c402c5"), CategoryName = "Пицария" },
                    new Category { Id = new Guid("2f2a0aa4-ef02-4ffa-ad36-f6abcb5cad3e"), CategoryName = "Бързо хранене" },
                    new Category { Id = new Guid("a3730467-ed8f-47d3-903e-cf6cb8aea583"), CategoryName = "Гръцка кухня" },
                    new Category { Id = new Guid("0068eb45-f381-4a34-8385-cec0e483df37"), CategoryName = "Българска кухня" },
                    new Category { Id = new Guid("3ce78111-d73b-431b-a52b-96b226fed723"), CategoryName = "Турска кухня" },
                    new Category { Id = new Guid("04ae13cb-8755-4f52-a6b0-53a8e05c3200"), CategoryName = "Азиатска кухня" },
                    new Category { Id = new Guid("e12d1204-3592-4caa-bd6b-3d5e3aca32d6"), CategoryName = "Морска храна" },
                    new Category { Id = new Guid("1b0f88fb-a91d-446e-8f5e-7a8602d2b901"), CategoryName = "Бистро" }
                };
                context.Categories.AddRange(categories);
                await context.SaveChangesAsync();
            }

            //Features
            if (!context.Features.Any())
            {
                var features = new List<Feature>
                {
                     new Feature { Id = new Guid("a43a3f1e-02d6-45a9-86a9-06cd2522a9cc"), Name = "Външен детски кът" },
                     new Feature { Id = new Guid("55b7cb27-7913-474a-bf44-5ddff365f959"), Name = "Градина" },
                     new Feature { Id = new Guid("977f158f-77d1-420a-9fcf-6fa6ea75bb38"), Name = "Място за пушачи" },
                     new Feature { Id = new Guid("5c9469f1-1b5c-4089-91e9-f8241fa4a805"), Name = "Вътрешен детски кът" },
                     new Feature { Id = new Guid("63d4971a-893f-4271-8412-52a924f99905"), Name = "Интернет" },
                     new Feature { Id = new Guid("9a4bf8ac-700f-4348-a70d-c91b992e48b8"), Name = "Паркинг" },
                     new Feature { Id = new Guid("4555dc2e-7693-4544-92c4-9ab807373a59"), Name = "Достъпност за инвалиди" },
                     new Feature { Id = new Guid("62f341ac-7dd5-4339-88e6-77c26954cb9a"), Name = "Доставка" },
                     new Feature { Id = new Guid("d68c6e75-bf22-4fd2-bf84-dd66a4073057"), Name = "Възможност за плащане с карта"}
                };
                context.Features.AddRange(features);
                await context.SaveChangesAsync();
            }

            //Restaurants
            if (!context.Restaurants.Any())
            {
                var restaurants = new List<Restaurant>
                {
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
                };

                context.Restaurants.AddRange(restaurants);
                await context.SaveChangesAsync();
            }

            if (!context.WorkTimeSchedules.Any())
            {
                var workTimeSchedule = new List<WorkTimeSchedule> {
                    new WorkTimeSchedule { Id = new Guid("4e2bbed5-ba4b-44b6-b16a-86de98a63ce0"), RestaurantId = new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b"),
                       Day = DayOfWeek.Monday, OpeningTime = new TimeSpan(11, 30, 00), ClosingTime = new TimeSpan(23, 30, 00)
                    },
                    new WorkTimeSchedule { Id = new Guid("dfe91a02-404b-4d36-8537-b1b82fe28d43"), RestaurantId = new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b"),
                       Day = DayOfWeek.Tuesday, OpeningTime = new TimeSpan(11, 30, 00), ClosingTime = new TimeSpan(23, 30, 00)
                    },
                    new WorkTimeSchedule { Id = new Guid("64bb2a3b-585c-48dd-9e0b-216ce8524a8c"), RestaurantId = new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b"),
                       Day = DayOfWeek.Wednesday, OpeningTime = new TimeSpan(11, 30, 00), ClosingTime = new TimeSpan(23, 30, 00)
                    },
                    new WorkTimeSchedule { Id = new Guid("53985eee-46ca-44e1-b457-4c3fc73e60c2"), RestaurantId = new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b"),
                       Day = DayOfWeek.Thursday, OpeningTime = new TimeSpan(11, 30, 00), ClosingTime = new TimeSpan(23, 30, 00)
                    },
                    new WorkTimeSchedule { Id = new Guid("16e600d3-5d1d-4f6a-afe0-2a8994f647df"), RestaurantId = new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b"),
                       Day = DayOfWeek.Friday, OpeningTime = new TimeSpan(11, 30, 00), ClosingTime = new TimeSpan(23, 30, 00)
                    },
                    new WorkTimeSchedule { Id = new Guid("f07de646-e32b-4e34-9031-a61d1f5d3437"), RestaurantId = new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b"),
                       Day = DayOfWeek.Saturday, OpeningTime = new TimeSpan(11, 30, 00), ClosingTime = new TimeSpan(23, 30, 00)
                    },
                    new WorkTimeSchedule { Id = new Guid("6355f560-db8e-43e5-b36b-1b282950f841"), RestaurantId = new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b"),
                       Day = DayOfWeek.Sunday, OpeningTime = new TimeSpan(12, 00, 00), ClosingTime = new TimeSpan(17, 30, 00)
                    },
                    new WorkTimeSchedule { Id = new Guid("3c519e19-9696-46a4-be31-1c42d886e1e5"), RestaurantId = new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342"),
                       Day = DayOfWeek.Monday, IsClosed = true,
                    },
                    new WorkTimeSchedule { Id = new Guid("acf0156c-7576-42d6-9b11-984d313aea51"), RestaurantId = new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342"),
                       Day = DayOfWeek.Tuesday, OpeningTime = new TimeSpan(8,30,00), ClosingTime = new TimeSpan(23,00,00)
                    },
                    new WorkTimeSchedule { Id = new Guid("c0790a6d-08c0-4470-a533-f19f40013672"), RestaurantId = new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342"),
                       Day = DayOfWeek.Wednesday, OpeningTime = new TimeSpan(8,30,00), ClosingTime = new TimeSpan(23,00,00)
                    },
                    new WorkTimeSchedule { Id = new Guid("010383fe-ebc4-48e2-b98e-2182e24bce31"), RestaurantId = new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342"),
                       Day = DayOfWeek.Thursday, OpeningTime = new TimeSpan(8,30,00), ClosingTime = new TimeSpan(23,00,00)
                    },
                    new WorkTimeSchedule { Id = new Guid("813f0637-9a00-4612-b5a4-3b2aee6ec6ac"), RestaurantId = new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342"),
                       Day = DayOfWeek.Friday, OpeningTime = new TimeSpan(8,30,00), ClosingTime = new TimeSpan(23,00,00)
                    },
                    new WorkTimeSchedule { Id = new Guid("b62049ab-ee45-4415-aa0c-690dd5b50ce5"), RestaurantId = new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342"),
                       Day = DayOfWeek.Saturday, OpeningTime = new TimeSpan(8,30,00), ClosingTime = new TimeSpan(23,00,00)
                    },
                    new WorkTimeSchedule { Id = new Guid("93255465-e52f-421c-b0df-ea6ef6696832"), RestaurantId = new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342"),
                       Day = DayOfWeek.Sunday, IsClosed = true
                    },
                    new WorkTimeSchedule { Id = new Guid("887e6c1a-0629-4ac2-b2fa-0370fbfbf763"), RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e"),
                       Day = DayOfWeek.Monday, OpeningTime = new TimeSpan(6, 00, 00), ClosingTime = new TimeSpan(22, 30, 00)
                    },
                    new WorkTimeSchedule { Id = new Guid("174bc1fe-a957-41d7-8a38-afb7c1c9a340"), RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e"),
                       Day = DayOfWeek.Tuesday, OpeningTime = new TimeSpan(6, 00, 00), ClosingTime = new TimeSpan(22, 30, 00)
                    },
                    new WorkTimeSchedule { Id = new Guid("be5b1bad-fd82-4850-9646-1d8de29532fa"), RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e"),
                       Day = DayOfWeek.Wednesday, OpeningTime = new TimeSpan(6, 00, 00), ClosingTime = new TimeSpan(22, 30, 00)
                    },
                    new WorkTimeSchedule { Id = new Guid("7cf04ef9-fd79-40f2-935a-12b0675a6307"), RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e"),
                       Day = DayOfWeek.Thursday, OpeningTime = new TimeSpan(6, 00, 00), ClosingTime = new TimeSpan(22, 30, 00)
                    },
                    new WorkTimeSchedule { Id = new Guid("898454a9-3569-4827-ae31-a6919a56351d"), RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e"),
                       Day = DayOfWeek.Friday, OpeningTime = new TimeSpan(6, 00, 00), ClosingTime = new TimeSpan(22, 30, 00)
                    },
                    new WorkTimeSchedule { Id = new Guid("357fa35e-6b3c-4c1d-bdfe-2951e0fc3547"), RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e"),
                       Day = DayOfWeek.Saturday, OpeningTime = new TimeSpan(6, 00, 00), ClosingTime = new TimeSpan(22, 30, 00)
                    },
                    new WorkTimeSchedule { Id = new Guid("fbf95d72-3540-414a-94be-0d126b97cceb"), RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e"),
                       Day = DayOfWeek.Sunday, OpeningTime = new TimeSpan(6, 00, 00), ClosingTime = new TimeSpan(22, 30, 00)
                    }
                };

                context.WorkTimeSchedules.AddRange(workTimeSchedule);
                await context.SaveChangesAsync();
            }

            if (!context.RestaurantCategories.Any())
            {
                var restaurantCategories = new List<RestaurantCategories>
                {
                    new RestaurantCategories { CategoryId = new Guid("4d8d411a-a288-4d94-a040-6d98126e7ed2"), RestaurantId = new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b") },
                    new RestaurantCategories { CategoryId = new Guid("4d8d411a-a288-4d94-a040-6d98126e7ed2"), RestaurantId = new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342") },
                    new RestaurantCategories { CategoryId = new Guid("a3730467-ed8f-47d3-903e-cf6cb8aea583"), RestaurantId = new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342") },
                    new RestaurantCategories { CategoryId = new Guid("0068eb45-f381-4a34-8385-cec0e483df37"), RestaurantId = new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342") },
                    new RestaurantCategories { CategoryId = new Guid("3ce78111-d73b-431b-a52b-96b226fed723"), RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    new RestaurantCategories { CategoryId = new Guid("0068eb45-f381-4a34-8385-cec0e483df37"), RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e") }
                };

                context.RestaurantCategories.AddRange(restaurantCategories);
                await context.SaveChangesAsync();
            }

            if (!context.RestaurantFeatures.Any())
            {
                var restaurantFeatures = new List<RestaurantFeature>
                {
                    new RestaurantFeature { FeatureId = new Guid("55b7cb27-7913-474a-bf44-5ddff365f959"), RestaurantId = new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b") },
                    new RestaurantFeature { FeatureId = new Guid("977f158f-77d1-420a-9fcf-6fa6ea75bb38"), RestaurantId = new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b") },
                    new RestaurantFeature { FeatureId = new Guid("63d4971a-893f-4271-8412-52a924f99905"), RestaurantId = new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b") },
                    new RestaurantFeature { FeatureId = new Guid("9a4bf8ac-700f-4348-a70d-c91b992e48b8"), RestaurantId = new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b") },
                    new RestaurantFeature { FeatureId = new Guid("4555dc2e-7693-4544-92c4-9ab807373a59"), RestaurantId = new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b") },
                    new RestaurantFeature { FeatureId = new Guid("62f341ac-7dd5-4339-88e6-77c26954cb9a"), RestaurantId = new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b") },
                    new RestaurantFeature { FeatureId = new Guid("d68c6e75-bf22-4fd2-bf84-dd66a4073057"), RestaurantId = new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b") },
                    new RestaurantFeature { FeatureId = new Guid("55b7cb27-7913-474a-bf44-5ddff365f959"), RestaurantId = new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342") },
                    new RestaurantFeature { FeatureId = new Guid("4555dc2e-7693-4544-92c4-9ab807373a59"), RestaurantId = new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342") },
                    new RestaurantFeature { FeatureId = new Guid("63d4971a-893f-4271-8412-52a924f99905"), RestaurantId = new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342") },
                    new RestaurantFeature { FeatureId = new Guid("62f341ac-7dd5-4339-88e6-77c26954cb9a"), RestaurantId = new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342") },
                    new RestaurantFeature { FeatureId = new Guid("d68c6e75-bf22-4fd2-bf84-dd66a4073057"), RestaurantId = new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342") },
                    new RestaurantFeature { FeatureId = new Guid("977f158f-77d1-420a-9fcf-6fa6ea75bb38"), RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    new RestaurantFeature { FeatureId = new Guid("63d4971a-893f-4271-8412-52a924f99905"), RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    new RestaurantFeature { FeatureId = new Guid("9a4bf8ac-700f-4348-a70d-c91b992e48b8"), RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    new RestaurantFeature { FeatureId = new Guid("4555dc2e-7693-4544-92c4-9ab807373a59"), RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    new RestaurantFeature { FeatureId = new Guid("62f341ac-7dd5-4339-88e6-77c26954cb9a"), RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    new RestaurantFeature { FeatureId = new Guid("d68c6e75-bf22-4fd2-bf84-dd66a4073057"), RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e") }
                };

                context.RestaurantFeatures.AddRange(restaurantFeatures);
                await context.SaveChangesAsync();
            }

            if (!context.RestaurantPhotos.Any())
            {
                var restaurantPhotos = new List<RestaurantPhoto>
                {
                    new RestaurantPhoto { Id = new Guid("815ac57b-45cd-4ed9-afc9-ec5ca6702060"), Photo = "/img/restaurants/delta1.png", RestaurantId= new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    new RestaurantPhoto { Id = new Guid("5e66a376-1951-4fec-ab24-088ddada70fa"), Photo = "/img/restaurants/delta2.png", RestaurantId= new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    new RestaurantPhoto { Id = new Guid("478d44ee-93b2-4260-a4e0-88e7bdf198ee"), Photo = "/img/restaurants/delta3.png", RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    new RestaurantPhoto { Id = new Guid("0a6d4d6a-c929-4afb-9993-84595f14bda3"), Photo = "/img/restaurants/delta4.png", RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    new RestaurantPhoto { Id = new Guid("e047ddf1-2c78-4b31-8ac8-7f3c101e3e83"), Photo = "/img/restaurants/delta5.png", RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e") }
                };

                context.RestaurantPhotos.AddRange(restaurantPhotos);
                await context.SaveChangesAsync();
            }

            if (!context.MenuItems.Any())
            {
                var menu = new List<MenuItem>
                {
                    new MenuItem { Id = new Guid("ae3fcc5d-b7ea-4058-8021-d1bf09520d40"), Photo = "/img/restaurants/menuDelta1.png", RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    new MenuItem { Id = new Guid("a8a301a9-5f9a-4a04-a9fc-5d23c9379bc3"), Photo = "/img/restaurants/menuDelta2.png", RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    new MenuItem { Id = new Guid("b921a7fc-4a25-45c2-8590-be88226ca9b7"), Photo = "/img/restaurants/menuDelta3.png", RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    new MenuItem { Id = new Guid("9fbe7d14-b74f-4607-8330-b2172d46c1b9"), Photo = "/img/restaurants/menuDelta4.png", RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    new MenuItem { Id = new Guid("8a6413a9-0868-4e2b-8c71-0c2a843bca28"), Photo = "/img/restaurants/menuDelta5.png", RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    new MenuItem { Id = new Guid("d50bdf0c-e315-4439-9d94-85ba2cad7069"), Photo = "/img/restaurants/menuDelta6.png", RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    new MenuItem { Id = new Guid("0d63a2e7-200a-4f21-8e29-c1c9592c76d8"), Photo = "/img/restaurants/menuDelta7.png", RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    new MenuItem { Id = new Guid("21c73c72-3656-4831-99af-f187847007dc"), Photo = "/img/restaurants/menuDelta8.png", RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    new MenuItem { Id = new Guid("9c4d530c-a0b7-4433-abff-b717f9b95d84"), Photo = "/img/restaurants/menuDelta9.png", RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    new MenuItem { Id = new Guid("52224042-89be-4c71-b91e-9c370e37f6c0"), Photo = "/img/restaurants/menuDelta10.png", RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    new MenuItem { Id = new Guid("841eeb59-eb0d-4d79-a1ff-c778201ad2df"), Photo = "/img/restaurants/menuDelta11.png", RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    new MenuItem { Id = new Guid("fbebc578-2f01-4226-aa1b-a0cb401921e4"), Photo = "/img/restaurants/menuDelta12.png", RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    new MenuItem { Id = new Guid("6fa06452-f7b6-4a74-be2d-634bdf12a292"), Photo = "/img/restaurants/menuDelta13.png", RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    new MenuItem { Id = new Guid("16e14eea-711b-43f0-a32b-67ccbdd2f83f"), Photo = "/img/restaurants/menuDelta14.png", RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    new MenuItem { Id = new Guid("488d1538-4276-43b1-b61c-f7832008386e"), Photo = "/img/restaurants/menuDelta15.png", RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    new MenuItem { Id = new Guid("c613e9a3-d2ae-494a-97d2-995966f32b45"), Photo = "/img/restaurants/menuDelta16.png", RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    new MenuItem { Id = new Guid("cc9a7227-d89c-4a94-99b0-79ebd9d990e4"), Photo = "/img/restaurants/menuDelta17.png", RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    new MenuItem { Id = new Guid("5206eca9-5c20-44be-bc08-48f628d52687"), Photo = "/img/restaurants/menuDelta18.png", RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    new MenuItem { Id = new Guid("e7743562-2ee1-4379-9058-0c045a08c803"), Photo = "/img/restaurants/menuDelta19.png", RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    new MenuItem { Id = new Guid("e4cf6a24-e078-4f4f-9654-ac6a58b400a7"), Photo = "/img/restaurants/menuDelta20.png", RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    new MenuItem { Id = new Guid("189a0770-4e56-4785-aa9c-8d8680db1d2a"), Photo = "/img/restaurants/menuDelta21.png", RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    new MenuItem { Id = new Guid("778b5ba9-57cb-4349-a773-2bc4badb4fc2"), Photo = "/img/restaurants/menuDelta22.png", RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    new MenuItem { Id = new Guid("bc4f36c1-b70a-4d91-b82e-473d5f3cfeb6"), Photo = "/img/restaurants/menuDelta23.png", RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e") }
                };

                context.MenuItems.AddRange(menu);
                await context.SaveChangesAsync();
            }

            if (!context.Reviews.Any())
            {
                var user = await userManager.FindByEmailAsync("tina@gmail.com"); // Use UserManager instead of direct query

                if (user != null)
                {
                    var reviews = new List<Review>
                    {
                        new Review { Id = new Guid("2e2038e6-181b-4808-8184-c38afb5a2ddc"), Rating = 5,
                        RestaurantId = new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b"), UserId = user.Id },
                        new Review { Id = new Guid("cdbded6f-d5d8-408b-a87c-b66f564e47af"), Rating = 5,
                        RestaurantId = new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342"), UserId = user.Id },
                        new Review { Id = new Guid("84e5975b-ad32-426f-93d5-03fa0545e802"), Rating = 5,
                        RestaurantId = new Guid("8670fecf-265e-4743-be6a-6477389cc15e"), UserId = user.Id }
                    };

                    context.Reviews.AddRange(reviews);
                    await context.SaveChangesAsync();
                }
            }

        }
    }
}
