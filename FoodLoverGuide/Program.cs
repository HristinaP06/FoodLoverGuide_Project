using CloudinaryDotNet;
using FoodLoverGuide.Core;
using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Core.Services;
using FoodLoverGuide.DataAccess;
using FoodLoverGuide.DataAccess.Repository;
using FoodLoverGuide.Models;
using FoodLoverGuide.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection, b => b.MigrationsAssembly("FoodLoverGuide.DataAccess")));

/*builder.Services.AddDefaultIdentity<User>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();*/

builder.Services.AddDefaultIdentity<User>(options =>
{

    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;

    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
    options.Lockout.MaxFailedAccessAttempts = 5;
})
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddRazorPages();

builder.Services.AddScoped(typeof(IRepository), typeof(Repository));

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IFeatureService, FeatureService>();
builder.Services.AddScoped<IMenuItemService, MenuItemService>();
builder.Services.AddScoped<IRatingService, RatingService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IRestaurantCategoriesService, RestaurantCategoriesService>();
builder.Services.AddScoped<IRestaurantFeatureService, RestaurantFeatureService>();
builder.Services.AddScoped<IRestaurantPhotoService, RestaurantPhotoService>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IWorkTimeScheduleService, WorkTimeScheduleService>();
builder.Services.AddScoped<CloudinaryService>();

// Регистриране на Cloudinary в DI контейнера     
var cloudinarySettings = builder.Configuration
                        .GetSection("Cloudinary")
                        .Get<CloudinarySettings>();

var account = new Account(cloudinarySettings.CloudName,
cloudinarySettings.ApiKey, cloudinarySettings.ApiSecret);

var cloudinary = new Cloudinary(account);
builder.Services.AddSingleton(cloudinary);


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    var userManager = services.GetRequiredService<UserManager<User>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    await DbInitializer.InitializeAsync(context, userManager, roleManager);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "Admin",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
