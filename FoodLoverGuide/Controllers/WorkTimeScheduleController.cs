using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Host;

namespace FoodLoverGuide.Controllers
{
    public class WorkTimeScheduleController : Controller
    {
        private readonly IWorkspaceService workspaceService;

        public WorkTimeScheduleController(IWorkspaceService workspaceService)
        {
            this.workspaceService = workspaceService;
        }

        public IActionResult IndexAsync()
        {
            return View();
        }
    }
}
