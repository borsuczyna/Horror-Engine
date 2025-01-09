using Microsoft.AspNetCore.Mvc;

namespace MasterList.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return new JsonResult(new { message = "Horror Engine Master List API" });
    }
}
