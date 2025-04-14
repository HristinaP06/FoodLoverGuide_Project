using FoodLoverGuide.Core.Constants;
using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Core.ViewModels.User;
using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodLoverGuide.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IReservationService reservationService;

        public UserController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IReservationService reservationService)
        {
            this.userManager = userManager;
            this.reservationService = reservationService;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(Guid id)
        {
            var user = await this.userManager.Users.Where(r => r.Id == id.ToString()).FirstOrDefaultAsync();

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

        [HttpGet]

        public async Task<IActionResult> Edit(Guid userId)
        {
            var user = await this.userManager.Users.Where(u => u.Id == userId.ToString()).FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            var model = new UserEditVM
            {
                Id = userId.ToString(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Age = user.Age
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserEditVM model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var user = await this.userManager.Users.Where(u => u.Id == model.Id).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound();
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.Age = model.Age;

            var result = await this.userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                TempData[MessageConstants.ErrorMessage] = "Имате проблем с данните!";
                return View(model);
            }

            if (!string.IsNullOrEmpty(model.CurrentPassword) && !string.IsNullOrEmpty(model.NewPassword))
            {
                if (model.NewPassword != model.ConfirmNewPassword)
                {
                    TempData[MessageConstants.ErrorMessage] = "Новата парола и потвърдената нова парола не съвпадат!";
                    return View(model);
                }

                var passwordChangeResult = await this.userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (!passwordChangeResult.Succeeded)
                {
                    foreach (var error in passwordChangeResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(model);
                }
            }

            TempData[MessageConstants.SuccessMessage] = "Вашата парола беше променена успешно.";

            return RedirectToAction("Index", new {id = new Guid(user.Id)});
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await this.userManager.Users.Where(u => u.Id == id.ToString()).FirstOrDefaultAsync();
            var result = await this.userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Unexpected error occurred deleting user.");
            }

            await this.signInManager.SignOutAsync();
            return Redirect("~/");
        }
    }
}
