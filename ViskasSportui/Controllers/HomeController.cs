using Microsoft.AspNetCore.Mvc;

namespace ViskasSportui.Controllers;

// Pagrindinis langas (bendras visai komandai)
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
