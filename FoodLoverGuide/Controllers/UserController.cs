using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Core.ViewModels.User;
using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodLoverGuide.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IReservationService reservationService;

        public UserController(UserManager<User> userManager, IReservationService reservationService)
        {
            this.userManager = userManager;
            this.reservationService = reservationService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(Guid id)
        {
            var user = this.userManager.Users.Where(r => r.Id == id.ToString()).FirstOrDefault();

                var model = new UserDisplayVM
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Age = user.Age,
                    Reservations = await reservationService.GetAll().Include(r => r.Restaurant).Where(u => u.UserId == id.ToString()).ToListAsync()
                };
            
            return View(model);
        }
    }
}
