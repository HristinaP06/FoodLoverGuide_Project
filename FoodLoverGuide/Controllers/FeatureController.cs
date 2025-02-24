using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FoodLoverGuide.Controllers
{
    public class FeatureController : Controller
    {
        private readonly IFeatureService service;

        public FeatureController(IFeatureService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            var list = await this.service.GetAll().ToListAsync();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Feature feature)
        {
            if (ModelState.IsValid)
            {
                await this.service.Add(feature);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var obj = await this.service.GetById(id);
            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Feature feature)
        {
            await this.service.Update(feature);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await this.service.Delete(id);
            return RedirectToAction("Index");
        }
	}
}
