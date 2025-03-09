using FoodLoverGuide.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodLoverGuide.Areas.Admin.Controllers
{
    [Authorize(Roles = $"{SD.AdminRole}")]
    [Area("Admin")]
    public class BaseController : Controller
    {
    }
}
