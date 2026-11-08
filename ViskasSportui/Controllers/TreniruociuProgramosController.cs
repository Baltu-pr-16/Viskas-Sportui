using Microsoft.AspNetCore.Mvc;

namespace ViskasSportui.Controllers // pakeiskite į savo projekto vardų erdvę
{
    public class TreniruociuProgramosController : Controller
    {
        public IActionResult Perziura() => View();
        public IActionResult ProgramosInfo() => View();
        public IActionResult Redaguoti() => View();
        public IActionResult RedagavimoPatvirtinimas() => View();
        public IActionResult Istrinti() => View();
    }
}
