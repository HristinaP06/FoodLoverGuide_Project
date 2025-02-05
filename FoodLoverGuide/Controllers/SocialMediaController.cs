using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodLoverGuide.Controllers
{
    public class SocialMediaController : Controller
    {
        private readonly ISocialMediaService _service;

        public SocialMediaController(ISocialMediaService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _service.GetAll().ToListAsync();
            return View(list);
        }

        public IActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(SocialMedia sm)
        {
            await _service.Add(sm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var obj = await _service.GetById(id);
            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SocialMedia sm)
        {
            await _service.Update(sm);
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
