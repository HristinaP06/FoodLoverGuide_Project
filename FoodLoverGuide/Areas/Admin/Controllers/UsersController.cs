using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Core.ViewModels.User;
using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodLoverGuide.Areas.Admin.Controllers
{
    public class UsersController : BaseController
    {
        private readonly UserManager<User> userManager;
        private readonly IReservationService reservationService;

        public UsersController(UserManager<User> userManager, IReservationService reservationService)
        {
            this.userManager = userManager;
            this.reservationService = reservationService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var list =  this.userManager.Users.ToList();
            var userVM = new List<UserVM>();

            foreach (var user in list)
            {
                var roles = await userManager.GetRolesAsync(user);
                var role = roles.FirstOrDefault();

                userVM.Add(new UserVM
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Role = role,
                });
            }

            return View(userVM);
        }

        [HttpGet]

        public async Task<IActionResult> Details(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }
            
            var user = this.userManager.Users.Where(u => u.Id == id.ToString()).First();

            if (user == null)
            {
                return NotFound();
            }

            var model = new UserDisplayVM
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Age = user.Age,
                Reservations = await reservationService.GetAll().Include(r => r.Restaurant).Where(u => u.UserId == id.ToString()).ToListAsync(),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var user = this.userManager.Users.Where(u => u.Id == id.ToString()).First();
            if(user == null)
            {
                return NotFound();
            }
            var result = await this.userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Unexpected error occurred deleting user.");
            }

            return RedirectToAction("Index");
        }
    }
}
