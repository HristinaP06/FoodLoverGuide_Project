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
        private readonly IContactService _contactService;
        private readonly IFeatureService _featureService;
        private readonly IWorkTimeScheduleService _workTimeScheduleService;
        private readonly IRestaurantCategoriesService _restaurantCategoriesService;
        private readonly IRestaurantFeatureService _restaurantFeatureService;

        public RestaurantController
            (IRestaurantService rService, ICategoryService categoryService, IContactService contactService, 
             IFeatureService featureService, IWorkTimeScheduleService workTimeScheduleService,
            IRestaurantCategoriesService restaurantCategoriesService, IRestaurantFeatureService restaurantFeatureService)
        {
            _rService = rService;
            _categoryService = categoryService;
            _contactService = contactService;
            _featureService = featureService;
            _workTimeScheduleService = workTimeScheduleService;
            _restaurantCategoriesService = restaurantCategoriesService;
            _restaurantFeatureService = restaurantFeatureService;
        }
        public async Task<IActionResult> Index()
        {
           
            var rest = await _rService.GetAll().ToListAsync();
            var contact = await _contactService.GetAll().ToListAsync();
            var model = rest.Select(r => new RestaurantDetailsViewModel
            {
                Name = r.Name,
                Description = r.Description,
                Location = r.Location,
                PriceRangeFrom = r.PriceRangeFrom,
                PriceRangeTo = r.PriceRangeTo,
                IndoorCapacity = r.IndoorCapacity,
                OutdoorCapacity = r.OutdoorCapacity
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
            var contact = new Contact()
            {
                Telephone = model.Telephone,
                Email = model.Email
            };
            await _contactService.Add(contact);  

            var workTime = new WorkTimeSchedule()
            {
                Date = model.Date,
                Start = model.Start,
                End = model.End
            };
            await _workTimeScheduleService.Add(workTime);  

           
            var restaurant = new Restaurant()
            {
                Name = model.Name,
                Description = model.Description,
                Location = model.Location,
                PriceRangeFrom = model.PriceRangeFrom,
                PriceRangeTo = model.PriceRangeTo,
                IndoorCapacity = model.IndoorCapacity,
                OutdoorCapacity = model.OutdoorCapacity,
                RestaurantContacts = contact 
            };

            await _rService.Add(restaurant);

            if (model.SelectedCategoriesId != null)
            {
                foreach( var category in model.SelectedCategoriesId)
                {
                    RestaurantCategories restaurantCategories = new RestaurantCategories()
                    {
                        CategoryId = category,
                        RestaurantId = restaurant.Id
                    };
                    _restaurantCategoriesService.Add(restaurantCategories);
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
                    _restaurantFeatureService.Add(restaurantFeauters);
                }
            }


            contact.RestaurantId = restaurant.Id;
            workTime.RestaurantId = restaurant.Id;
            await _workTimeScheduleService.Update(workTime);
            await _contactService.Update(contact);

            return RedirectToAction("Index");
            
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var obj = await _rService.GetById(id);
            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RestaurantDetailsViewModel restaurant)
        {
            
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var restaurant = await _rService.GetAll().Include(r => r.RestaurantCategoriesList).FirstOrDefaultAsync(c => c.Id == id);
            

            await _rService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
