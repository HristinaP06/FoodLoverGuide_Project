using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodLoverGuide.Controllers
{
    public class FeatureController : Controller
    {
        private readonly IFeatureService _service;

        public FeatureController(IFeatureService service)
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
        public async Task<IActionResult> Create(Feature feature)
        {
            await _service.Add(feature);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var obj = await _service.GetById(id);
            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Feature feature)
        {
            await _service.Update(feature);
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
