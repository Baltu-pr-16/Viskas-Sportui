using Microsoft.AspNetCore.Mvc;

namespace ViskasSportui.Controllers // pakeiskite į savo projekto vardų erdvę
{
    public class TreniruotesController : Controller
    {
        public IActionResult IntensyvumoSkaiciavimas() => View();
        public IActionResult SkaiciavimoRezultatas() => View();
        public IActionResult Sudaryti() => View();
        public IActionResult TreniruotesPlanas() => View();
    }
}
