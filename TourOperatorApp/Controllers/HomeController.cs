using Microsoft.AspNetCore.Mvc;


namespace TourOperatorApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();
}