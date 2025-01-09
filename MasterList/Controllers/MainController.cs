using Microsoft.AspNetCore.Mvc;

namespace MasterList.Controllers;

[ApiController]
[Route("/")]
public class MainController : Controller
{
    private readonly ILogger<MainController> _logger;

    public MainController(ILogger<MainController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return new ContentResult
        {
            Content = "Horror Engine Master List",
            ContentType = "text/plain",
            StatusCode = 200
        };
    }
}