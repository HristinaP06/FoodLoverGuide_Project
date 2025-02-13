using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Models;
using FoodLoverGuide.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared.Project;
using Microsoft.EntityFrameworkCore;

namespace FoodLoverGuide.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurantService _rService;
        private readonly ICategoryService _categoryService;
        private readonly IFeatureService _featureService;
        private readonly IWorkTimeScheduleService _workTimeScheduleService;
        private readonly IRestaurantCategoriesService _restaurantCategoriesService;
        private readonly IRestaurantFeatureService _restaurantFeatureService;

        public RestaurantController
            (IRestaurantService rService, ICategoryService categoryService,IFeatureService featureService, IWorkTimeScheduleService workTimeScheduleService,
            IRestaurantCategoriesService restaurantCategoriesService, IRestaurantFeatureService restaurantFeatureService)
        {
            _rService = rService;
            _categoryService = categoryService;
            _featureService = featureService;
            _workTimeScheduleService = workTimeScheduleService;
            _restaurantCategoriesService = restaurantCategoriesService;
            _restaurantFeatureService = restaurantFeatureService;
        }

        public async Task<IActionResult> Index()
        {
            var rest = await _rService.GetAll().Include(x => x.Features).Include(x => x.RestaurantCategoriesList).ToListAsync();
            var model = rest.Select(r => new RestaurantDetailsViewModel
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                Location = r.Location,
                PriceRangeFrom = r.PriceRangeFrom,
                PriceRangeTo = r.PriceRangeTo,
                IndoorCapacity = r.IndoorCapacity,
                OutdoorCapacity = r.OutdoorCapacity,
                SelectedCategoriesId = r.RestaurantCategoriesList.Select(c => c.CategoryId).ToList(),
                SelectedFeaturesId = r.Features.Select(f => f.FeatureId).ToList(),
                Categories = r.RestaurantCategoriesList.Select(x => new SelectListItem() { Value = x.Category.CategoryName }).ToList(),
                Features = r.Features.Select(x => new SelectListItem() { Value = x.Features.Name}).ToList(),
                Telephone = r.Telephone,
                Email = r.Email,
                Instagram = r.Instagram,
                Facebook = r.Facebook,
                WebSite = r.WebSite
            });
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAll().ToListAsync();
            var features = await _featureService.GetAll().ToListAsync();

            var model = new RestaurantDetailsViewModel()
            {
                Categories = categories.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.CategoryName
                }).ToList(),
                Features = features.Select(f => new SelectListItem
                {
                    Value = f.Id.ToString(),
                    Text = f.Name
                }).ToList()
            };
            return View(model);
        }

        
        [HttpPost]
        public async Task<IActionResult> Create(RestaurantDetailsViewModel model)
        {
            var workTime = new WorkTimeSchedule()
            {
                Date = model.Date, 
                Start = model.Start,
                End = model.End
            };
            await _workTimeScheduleService.Add(workTime);  


           
            var restaurant = new Restaurant()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Location = model.Location,
                PriceRangeFrom = model.PriceRangeFrom,
                PriceRangeTo = model.PriceRangeTo,
                IndoorCapacity = model.IndoorCapacity,
                OutdoorCapacity = model.OutdoorCapacity,
                Telephone = model.Telephone,
                Email = model.Email,
                Instagram = model.Instagram,
                Facebook = model.Facebook,
                WebSite = model.WebSite
            };

            await _rService.Add(restaurant);

            if (model.SelectedCategoriesId != null)
            {
                foreach( var category in model.SelectedCategoriesId)
                {
                    RestaurantCategories restaurantCategories = new RestaurantCategories()
                    {
                        CategoryId = category,
                        RestaurantId = restaurant.Id,
                        Restaurant = restaurant,
                        Category = await _categoryService.GetAll().Where(x => x.Id == category).Select(x => x).FirstAsync()
                    };
                    restaurant?.RestaurantCategoriesList?.Add(restaurantCategories);
                    await _restaurantCategoriesService.Add(restaurantCategories);
                    
                    
                }
            }

            if (model.SelectedFeaturesId != null)
            {
                foreach (var feature in model.SelectedFeaturesId)
                {
                    RestaurantFeature restaurantFeauters = new RestaurantFeature()
                    {
                        FeatureId = feature,
                        RestaurantId = restaurant.Id,
                        Restaurants = restaurant,
                        Features = await _featureService.GetAll().Where(x => x.Id == feature).Select(x => x).FirstAsync()
                    };
                    restaurant?.Features?.Add(restaurantFeauters);
                    await _restaurantFeatureService.Add(restaurantFeauters);
                    
                }
            }

            workTime.RestaurantId = restaurant.Id;
            await _rService.Update(restaurant);
            await _workTimeScheduleService.Update(workTime);
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var obj = await _rService.GetById(id);
            var vm = new RestaurantDetailsViewModel
            {
                Name = obj.Name,
                Description = obj.Description,
                Location = obj.Location,
                PriceRangeFrom = obj.PriceRangeFrom,
                PriceRangeTo = obj.PriceRangeTo,
                IndoorCapacity = obj.IndoorCapacity,
                OutdoorCapacity = obj.OutdoorCapacity,
                Telephone = obj.Telephone,
                Email = obj.Email,
                Instagram = obj.Instagram,
                Facebook = obj.Facebook,
                WebSite = obj.WebSite
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RestaurantDetailsViewModel model)
        {
            var workTime = new WorkTimeSchedule()
            {
                Date = model.Date,
                Start = model.Start,
                End = model.End
            };
            await _workTimeScheduleService.Update(workTime);


            var restaurant = new Restaurant()
            {
                Name = model.Name,
                Description = model.Description,
                Location = model.Location,
                PriceRangeFrom = model.PriceRangeFrom,
                PriceRangeTo = model.PriceRangeTo,
                IndoorCapacity = model.IndoorCapacity,
                OutdoorCapacity = model.OutdoorCapacity,
                Telephone = model.Telephone,
                Email = model.Email,
                Instagram = model.Instagram,
                Facebook = model.Facebook,
                WebSite = model.WebSite
            };

            await _rService.Update(restaurant);

            if (model.SelectedCategoriesId != null)
            {
                foreach (var category in model.SelectedCategoriesId)
                {
                    RestaurantCategories restaurantCategories = new RestaurantCategories()
                    {
                        CategoryId = category,
                        RestaurantId = restaurant.Id
                    };
                    _restaurantCategoriesService.Update(restaurantCategories);
                }
            }

            if (model.SelectedFeaturesId != null)
            {
                foreach (var feature in model.SelectedFeaturesId)
                {
                    RestaurantFeature restaurantFeauters = new RestaurantFeature()
                    {
                        FeatureId = feature,
                        RestaurantId = restaurant.Id
                    };
                    _restaurantFeatureService.Update(restaurantFeauters);
                }
            }

            workTime.RestaurantId = restaurant.Id;

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _rService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
