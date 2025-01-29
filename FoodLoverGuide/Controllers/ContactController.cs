using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodLoverGuide.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _service;

        public ContactController(IContactService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _service.GetAll();
            return View(list);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Contact contact)
        {
            await _service.Add(contact);
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public async Task<IActionResult> Edit(Contact contact)
        //{

        //}

    }
}
