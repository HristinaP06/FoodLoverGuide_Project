using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Models;
using FoodLoverGuide.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FoodLoverGuide.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurantService _rService;
        private readonly ICategoryService _categoryService;
        private readonly IContactService _contactService;
        private readonly ISocialMediaService _socialMediaService;
        private readonly IFeatureService _featureService;
        private readonly IWorkTimeScheduleService _workTimeScheduleService;

        public RestaurantController
            (IRestaurantService rService, ICategoryService categoryService, IContactService contactService, 
            ISocialMediaService socialMediaService, IFeatureService featureService, IWorkTimeScheduleService workTimeScheduleService)
        {
            _rService = rService;
            _categoryService = categoryService;
            _contactService = contactService;
            _socialMediaService = socialMediaService;
            _featureService = featureService;
            _workTimeScheduleService = workTimeScheduleService;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _rService.GetAll().ToListAsync();
            return View(list);
        }

        public async Task<IActionResult> Add()
        {
            
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Add(RestaurantDetailsViewModel restaurantDetailsViewModel)
        {
            
            var sm = new SocialMedia()
            {
                Media = restaurantDetailsViewModel.Media
            };
            await _socialMediaService.Add(sm);  

            restaurantDetailsViewModel.SocialMedias = new List<SocialMedia> { sm };  

            
            var contact = new Contact()
            {
                Telephone = restaurantDetailsViewModel.Telephone,
                Email = restaurantDetailsViewModel.Email,
                SocialMedia = restaurantDetailsViewModel.SocialMedias, 
            };
            await _contactService.Add(contact);  

            
            sm.ContactId = contact.Id;
            await _socialMediaService.Update(sm);  

            
            var workTime = new WorkTimeSchedule()
            {
                Date = restaurantDetailsViewModel.Date,
                Start = restaurantDetailsViewModel.Start,
                End = restaurantDetailsViewModel.End
            };
            await _workTimeScheduleService.Add(workTime);  

           
            var restaurant = new Restaurant()
            {
                Name = restaurantDetailsViewModel.Name,
                Description = restaurantDetailsViewModel.Description,
                Location = restaurantDetailsViewModel.Location,
                PriceRangeFrom = restaurantDetailsViewModel.PriceRangeFrom,
                PriceRangeTo = restaurantDetailsViewModel.PriceRangeTo,
                IndoorCapacity = restaurantDetailsViewModel.IndoorCapacity,
                OutdoorCapacity = restaurantDetailsViewModel.OutdoorCapacity,
                RestaurantContacts = contact 
            };

            await _rService.Add(restaurant);  

            contact.RestaurantId = restaurant.Id;
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
        public async Task<IActionResult> Edit(Restaurant restaurant)
        {
            await _rService.Update(restaurant);
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
