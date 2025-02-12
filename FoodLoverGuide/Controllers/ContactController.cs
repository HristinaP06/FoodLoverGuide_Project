using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var list = await _service.GetAll().ToListAsync();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Contact contact)
        {
            await _service.Add(contact);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var obj = await _service.GetById(id);
            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Contact contact)
        {
            await _service.Update(contact);
            return RedirectToAction("Index");
        }

        [HttpPost]

        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
