using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodLoverGuide.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceRangeFrom = table.Column<double>(type: "float", nullable: true),
                    PriceRangeTo = table.Column<double>(type: "float", nullable: true),
                    IndoorCapacity = table.Column<int>(type: "int", nullable: true),
                    OutdoorCapacity = table.Column<int>(type: "int", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RestaurantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItems_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    _Rating = table.Column<int>(type: "int", nullable: true),
                    RestaurantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RestaurantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Adults = table.Column<int>(type: "int", nullable: true),
                    Children = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantCategories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RestaurantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantCategories", x => new { x.CategoryId, x.RestaurantId });
                    table.ForeignKey(
                        name: "FK_RestaurantCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantCategories_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantFeatures",
                columns: table => new
                {
                    FeatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RestaurantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantFeatures", x => new { x.FeatureId, x.RestaurantId });
                    table.ForeignKey(
                        name: "FK_RestaurantFeatures_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantFeatures_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantPhotos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RestaurantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantPhotos_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestaurantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkTimeSchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RestaurantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    OpeningTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ClosingTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTimeSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkTimeSchedules_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("0068eb45-f381-4a34-8385-cec0e483df37"), "Българска кухня" },
                    { new Guid("04ae13cb-8755-4f52-a6b0-53a8e05c3200"), "Азиатска кухня" },
                    { new Guid("1b0f88fb-a91d-446e-8f5e-7a8602d2b901"), "Бистро" },
                    { new Guid("2f2a0aa4-ef02-4ffa-ad36-f6abcb5cad3e"), "Бързо хранене" },
                    { new Guid("3ce78111-d73b-431b-a52b-96b226fed723"), "Турска кухня" },
                    { new Guid("4d8d411a-a288-4d94-a040-6d98126e7ed2"), "Италианска кухня" },
                    { new Guid("7c9975a1-fd38-4495-93d2-38ae09c402c5"), "Пицария" },
                    { new Guid("a3730467-ed8f-47d3-903e-cf6cb8aea583"), "Гръцка кухня" },
                    { new Guid("e12d1204-3592-4caa-bd6b-3d5e3aca32d6"), "Морска храна" }
                });

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4555dc2e-7693-4544-92c4-9ab807373a59"), "Достъпност за инвалиди" },
                    { new Guid("55b7cb27-7913-474a-bf44-5ddff365f959"), "Градина" },
                    { new Guid("5c9469f1-1b5c-4089-91e9-f8241fa4a805"), "Вътрешен детски кът" },
                    { new Guid("62f341ac-7dd5-4339-88e6-77c26954cb9a"), "Доставка" },
                    { new Guid("63d4971a-893f-4271-8412-52a924f99905"), "Интерннет" },
                    { new Guid("977f158f-77d1-420a-9fcf-6fa6ea75bb38"), "Място за пушачи" },
                    { new Guid("9a4bf8ac-700f-4348-a70d-c91b992e48b8"), "Паркинг" },
                    { new Guid("a43a3f1e-02d6-45a9-86a9-06cd2522a9cc"), "Външен детски кът" },
                    { new Guid("d68c6e75-bf22-4fd2-bf84-dd66a4073057"), "Възможност за плащане с карта" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Description", "Email", "Facebook", "IndoorCapacity", "Instagram", "Location", "Name", "OutdoorCapacity", "PriceRangeFrom", "PriceRangeTo", "Telephone", "WebSite" },
                values: new object[,]
                {
                    { new Guid("39fbf8da-7b50-4f65-b3c8-3601e9adcd33"), "Минавайки покрай Музея на розите, посетете този ресторант. Потопете се в прекрасната българска кухня на това място. Топлата атмосфера на Ресторант Опела кара клиентите да се чувстват спокойни и да си прекарват приятно. Членовете на персонала са креативни и това прави това място толкова добро. Доброто обслужване е нещо, което клиентите харесват тук. Според мненията на рецензентите, цените са справедливи.", "", "", 75, "restorant_opela", "ул. 'Сергей Румянцев' 1А, Казанлък", "Ресторант Опела", 75, 20.0, 30.0, "043170299", "" },
                    { new Guid("4f3f68d3-3d1b-4dd1-8c7e-3686ee3bdc35"), "Елате в този ресторант, за да вечеряте, ако сте гладни, след като сте разгледали Музея на розите. Ресторант \"Сезони\" предлага добро кафе сред своите напитки. Уютната атмосфера на това място кара гостите да се чувстват спокойни и да си прекарват приятно. Казват, че сервитьорът тук е весел. Страхотното обслужване демонстрира високо ниво на качество в този ресторант. Много рецензенти отбелязват, че цените са демократични за това, което получавате.", "bistrosezoni@abv.bg", "Sezoni", 60, "", "ул. 'Кадемлия' 31, Казанлък", "Сезони", 60, 10.0, 20.0, "0877300166", "" },
                    { new Guid("64bf4496-2ffe-41f9-b6e1-8cb6a167b001"), "Ако дъждът ви изненада по време на разходката около Национален парк-музей Шипка-Бузлужа, отбийте се в този ресторант. Много хора казват, че тук сервитьорите сервират добра пица, пилешки крилца и свинско. Не пропускайте възможността да поръчате вкусна бира. Тук можете да пиете страхотно кафе. Лесно е да намерите Bellezza поради удобното местоположение. Компетентният персонал работи усилено, остава позитивен и прави това място страхотно. Приятното обслужване е голямо предимство на това място. От гледна точка на гостите цените са атрактивни. Със сигурност ще се насладите на приятната атмосфера.", "bellezzacafebar@gmail.com", "Bellezza Cafe Bar", 60, "", "ул. 'Отец Паисий Хилендарски' 2А, Казанлък", "Bellezza", 20, 18.0, 45.0, "0894521260", "" },
                    { new Guid("68bde11b-41a4-4f72-8dd1-f9b1b2a16eed"), " Да опитате перфектно приготвена пица и хубави салати е наистина добра идея. Удобната локация на Pizza Iskra / Пицария Искра я прави лесно достъпна дори и в пиковите часове. Повечето посетители твърдят, че служителите са гостоприемни. Ако искате да изпитате страхотно обслужване, трябва да посетите това място. Цените са адекватни тук. Може да обърнете внимание на приятната атмосфера.", "", "Пицария ИСКРА", 40, "pizzariaiskra", "ул. 'Искра' 18, Казанлък", "Пицария Искра", 30, 18.0, 45.0, "043159901", "" },
                    { new Guid("8670fecf-265e-4743-be6a-6477389cc15e"), "Гостите казват, че тук харесват италианската и турската кухня. Ресторант Делта осигурява доставка на храна за удобство на своите клиенти. Внимателният персонал работи усилено, остава позитивен и прави това място страхотно. Доброто обслужване показва високо ниво на качество на това място. Според мненията на рецензентите цените са средни. Със сигурност ще оцените спокойната атмосфера", "delta.restaurant.pizza@gmail.com", "Ресторант Делта", 100, "delta.restaurant.pizza", "ул. 'Бачо Киро' 2, Казанлък", "Ресторант Делта", 0, 18.0, 45.0, "0888655655", "" },
                    { new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342"), "Исторически музей Искра може да бъде на вашия маршрут по подразбиране, съветът на клиентите е да посетите този ресторант. Потопете се в прекрасната гръцка и италианска кухня на това място. Заслужава си да посетите Meraki Urban Gastro Lounge за добри бургери, салати капрезе и свинско. Тук можете да поръчате вкусно вино. Уютната атмосфера на това място кара гостите да се чувстват спокойни и да си прекарват приятно. Успехът на това място не би бил възможен без любезния персонал. Доброто обслужване е нещо, което посетителите отбелязват в отзивите си. В този ресторант се очакват адекватни цени.", "", "Meraki Urban Gastro Lounge ", 30, "meraki_alldayfoodexperience", "ул. 'Чудомир' 6, Казанлък", "Meraki Urban Gastro Lounge", 30, 18.0, 45.0, "0898909098", "" },
                    { new Guid("da5d839b-a421-430b-91df-3bbf866ed69c"), "Посетете това място и опитайте китайската кухня. Доставката на храна е голям плюс на този ресторант. Успехът на Ko Shi Yam би бил невъзможен без опитния персонал. Доброто обслужване е нещо, което гостите отбелязват в отзивите си. Ще плащате ниски цени за ястия. През повечето време уютната атмосфера се намира тук.", "", "Ко Ши Ям (Китайски ресторант) ", 30, "koshiqmkz", "ул. 'Цар Петър' 29, Казанлък", "Ko Shi Yam", 30, 15.0, 30.0, "043181320", "ko-shi-iam.com" },
                    { new Guid("e17f320c-0a7a-4bec-ae33-f736b57391a6"), "Този бар ви осигурява вкусна храна и място за почивка след дълга разходка из Исторически музей Искра. Яденето на перфектно сготвени спагети карбонара, пиле и салати е това, което редица гости препоръчват. Свежата атмосфера на това място позволява на клиентите да се отпуснат след тежък работен ден. Симпатичният персонал работи усилено, остава позитивен и прави това място страхотно. Готиното обслужване е голям плюс на това място. Повечето рецензенти споменават, че цените са разумни за това, което получавате.", "", "Bellezza Bar & Grill", 100, "bellezzabargrill", "ул. 'Старозагорска' 2А, Казанлък", "Bellezza - Bar & Grill", 30, 10.0, 30.0, "0899322690", "" },
                    { new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b"), "Трябва да се посети не само Исторически музей Искра, но и Marcon Italian Cuisine. Посетителите посочват, че е добре да отидете тук за италианска храна. Този ресторант е за препоръчване за добре приготвени пици, паста и салати. Както твърдят много рецензенти, лимонадата е наистина страхотна.Уютната атмосфера на Marcon Italian Cuisine дава  възможност на гостите да релаксират след тежък работен ден. Приятният персонал работи усилено, остава позитивен и прави това място страхотно. Обслужването на това място е нещо, което човек може да нарече бързо. Ще харесате справедливи цени.", "marconpizza@gmail.com", "Marcon Italian Cuisine", 60, "marcon_italian_cuisine", "ул. 'Любен Каравелов' 3, Казанлък", "Marcon Italian Cuisine", 60, 18.0, 45.0, "0883530101", "" },
                    { new Guid("fdd8e014-aa7c-4d36-b83e-d00750c552ad"), "След като разгледахте Исторически музей Искра, време е да си починете в този ресторант. Заповядайте в ресторант Лагуна за почивка и опитайте перфектно приготвено американско филе, риба и салати. Време е да дегустирате вкусно вино.Топлата атмосфера на това място кара гостите да се чувстват спокойни и да си прекарват приятно. Готиният персонал демонстрира високо ниво на гостоприемство на това място. Невероятното обслужване е нещо, което хората отбелязват в отзивите си. Този ресторант ви предлага добри цени за вкусни ястия.", "", "Restorant Laguna", 100, "", "бул. 'Никола Петков' 37А, Казанлък", "Ресторант Лагуна", 100, 18.0, 45.0, "043176767", "" }
                });

            migrationBuilder.InsertData(
                table: "RestaurantCategories",
                columns: new[] { "CategoryId", "RestaurantId" },
                values: new object[,]
                {
                    { new Guid("0068eb45-f381-4a34-8385-cec0e483df37"), new Guid("64bf4496-2ffe-41f9-b6e1-8cb6a167b001") },
                    { new Guid("0068eb45-f381-4a34-8385-cec0e483df37"), new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342") },
                    { new Guid("0068eb45-f381-4a34-8385-cec0e483df37"), new Guid("e17f320c-0a7a-4bec-ae33-f736b57391a6") },
                    { new Guid("4d8d411a-a288-4d94-a040-6d98126e7ed2"), new Guid("64bf4496-2ffe-41f9-b6e1-8cb6a167b001") },
                    { new Guid("4d8d411a-a288-4d94-a040-6d98126e7ed2"), new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342") },
                    { new Guid("4d8d411a-a288-4d94-a040-6d98126e7ed2"), new Guid("e17f320c-0a7a-4bec-ae33-f736b57391a6") },
                    { new Guid("4d8d411a-a288-4d94-a040-6d98126e7ed2"), new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b") },
                    { new Guid("7c9975a1-fd38-4495-93d2-38ae09c402c5"), new Guid("64bf4496-2ffe-41f9-b6e1-8cb6a167b001") },
                    { new Guid("a3730467-ed8f-47d3-903e-cf6cb8aea583"), new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342") },
                    { new Guid("e12d1204-3592-4caa-bd6b-3d5e3aca32d6"), new Guid("e17f320c-0a7a-4bec-ae33-f736b57391a6") }
                });

            migrationBuilder.InsertData(
                table: "RestaurantFeatures",
                columns: new[] { "FeatureId", "RestaurantId" },
                values: new object[,]
                {
                    { new Guid("4555dc2e-7693-4544-92c4-9ab807373a59"), new Guid("64bf4496-2ffe-41f9-b6e1-8cb6a167b001") },
                    { new Guid("4555dc2e-7693-4544-92c4-9ab807373a59"), new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342") },
                    { new Guid("4555dc2e-7693-4544-92c4-9ab807373a59"), new Guid("e17f320c-0a7a-4bec-ae33-f736b57391a6") },
                    { new Guid("4555dc2e-7693-4544-92c4-9ab807373a59"), new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b") },
                    { new Guid("55b7cb27-7913-474a-bf44-5ddff365f959"), new Guid("64bf4496-2ffe-41f9-b6e1-8cb6a167b001") },
                    { new Guid("55b7cb27-7913-474a-bf44-5ddff365f959"), new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342") },
                    { new Guid("55b7cb27-7913-474a-bf44-5ddff365f959"), new Guid("e17f320c-0a7a-4bec-ae33-f736b57391a6") },
                    { new Guid("55b7cb27-7913-474a-bf44-5ddff365f959"), new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b") },
                    { new Guid("62f341ac-7dd5-4339-88e6-77c26954cb9a"), new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342") },
                    { new Guid("62f341ac-7dd5-4339-88e6-77c26954cb9a"), new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b") },
                    { new Guid("63d4971a-893f-4271-8412-52a924f99905"), new Guid("64bf4496-2ffe-41f9-b6e1-8cb6a167b001") },
                    { new Guid("63d4971a-893f-4271-8412-52a924f99905"), new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342") },
                    { new Guid("63d4971a-893f-4271-8412-52a924f99905"), new Guid("e17f320c-0a7a-4bec-ae33-f736b57391a6") },
                    { new Guid("63d4971a-893f-4271-8412-52a924f99905"), new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b") },
                    { new Guid("977f158f-77d1-420a-9fcf-6fa6ea75bb38"), new Guid("64bf4496-2ffe-41f9-b6e1-8cb6a167b001") },
                    { new Guid("977f158f-77d1-420a-9fcf-6fa6ea75bb38"), new Guid("e17f320c-0a7a-4bec-ae33-f736b57391a6") },
                    { new Guid("977f158f-77d1-420a-9fcf-6fa6ea75bb38"), new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b") },
                    { new Guid("9a4bf8ac-700f-4348-a70d-c91b992e48b8"), new Guid("64bf4496-2ffe-41f9-b6e1-8cb6a167b001") },
                    { new Guid("9a4bf8ac-700f-4348-a70d-c91b992e48b8"), new Guid("e17f320c-0a7a-4bec-ae33-f736b57391a6") },
                    { new Guid("9a4bf8ac-700f-4348-a70d-c91b992e48b8"), new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b") },
                    { new Guid("d68c6e75-bf22-4fd2-bf84-dd66a4073057"), new Guid("64bf4496-2ffe-41f9-b6e1-8cb6a167b001") },
                    { new Guid("d68c6e75-bf22-4fd2-bf84-dd66a4073057"), new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342") },
                    { new Guid("d68c6e75-bf22-4fd2-bf84-dd66a4073057"), new Guid("e17f320c-0a7a-4bec-ae33-f736b57391a6") },
                    { new Guid("d68c6e75-bf22-4fd2-bf84-dd66a4073057"), new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_RestaurantId",
                table: "MenuItems",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_RestaurantId",
                table: "Ratings",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RestaurantId",
                table: "Reservations",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantCategories_RestaurantId",
                table: "RestaurantCategories",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantFeatures_RestaurantId",
                table: "RestaurantFeatures",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantPhotos_RestaurantId",
                table: "RestaurantPhotos",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_RestaurantId",
                table: "Reviews",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTimeSchedules_RestaurantId",
                table: "WorkTimeSchedules",
                column: "RestaurantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "RestaurantCategories");

            migrationBuilder.DropTable(
                name: "RestaurantFeatures");

            migrationBuilder.DropTable(
                name: "RestaurantPhotos");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "WorkTimeSchedules");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
