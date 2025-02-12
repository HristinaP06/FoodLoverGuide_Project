using FoodLoverGuide.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FoodLoverGuide.DataAccess.Repository;
using FoodLoverGuide.Core;
using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Core.Services;
using FoodLoverGuide.Utility;
using Microsoft.AspNetCore.Identity.UI.Services;
using FoodLoverGuide.Models;
using Microsoft.Build.Execution;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection, b => b.MigrationsAssembly("FoodLoverGuide.DataAccess")));



builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders(); 

builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddRazorPages();
//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IContactService, ContactService>();
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

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
    AddCookie(options => 
    { options.LoginPath = "/Account/Login"; options.AccessDeniedPath = "/Account/AccessDenied"; });

var app = builder.Build();

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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
