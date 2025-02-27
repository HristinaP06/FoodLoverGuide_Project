using FoodLoverGuide.Core.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Host;
using Microsoft.EntityFrameworkCore;

namespace FoodLoverGuide.Controllers
{
    public class WorkTimeScheduleController : Controller
    {
        private readonly IWorkTimeScheduleService workTimeScheduleService;

        public WorkTimeScheduleController(IWorkTimeScheduleService workTimeScheduleService)
        {
            this.workTimeScheduleService = workTimeScheduleService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var list = this.workTimeScheduleService.GetAll().ToListAsync();
            return View(list);
        }
    }
}
