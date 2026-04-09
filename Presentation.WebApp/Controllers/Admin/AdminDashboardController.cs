using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Controllers.Admin;

[Area("Admin")]
[Authorize(Roles = "Admin")]
[Route("admin")]
public class AdminDashboardController : Controller
{   
    public IActionResult Index()
    {
        return RedirectToAction(actionName: "Dashboard", controllerName: "Admin", routeValues: new { area = "Admin" });
    }
}
