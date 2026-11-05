using Microsoft.AspNetCore.Mvc;
using ViskasSportui.Models;

namespace ViskasSportui.Controllers;

// „Naudotojų paskyrų valdiklis“ (analizės diagramos 3.31–3.33).
// Prototipe tikros autentifikacijos nėra: prisijungus naudotojo rolė tik įrašoma į slapuką „Role“.
public class PaskyrosController : Controller
{
    // Registracijos langas (3.12 pav.).
    // Langas pats parodo, kad funkcija prieinama tik svečiui.
    public IActionResult Registracija()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Registracija(string elPastas, string slaptazodis, string slaptazodisPakartoti)
    {
        if (string.IsNullOrWhiteSpace(elPastas) || string.IsNullOrWhiteSpace(slaptazodis) || slaptazodis != slaptazodisPakartoti)
        {
            ViewBag.Klaida = "Registracija nepavyko: įveskite el. paštą ir du vienodus slaptažodžius.";
        }
        else
        {
            ViewBag.Sekme = "Registracija sėkminga.";
        }

        // Po registracijos liekama registracijos lange
        return View();
    }

    // Prisijungimo langas (3.13 pav.)
    public IActionResult Prisijungimas()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Prisijungimas(string elPastas, string slaptazodis)
    {
        // Prisijungti gali tik svečias. Prisijungusiam langas parodo, kad funkcija neprieinama.
        if (Request.Cookies["Role"] != null)
        {
            return View();
        }

        // Tikrinami prisijungimo duomenys: ieškoma demonstracinė paskyra su tokiu el. paštu ir slaptažodžiu
        DemoPaskyra rastaPaskyra = null;
        foreach (DemoPaskyra paskyra in DemoDuomenys.Paskyros)
        {
            if (paskyra.ElPastas == elPastas && paskyra.Slaptazodis == slaptazodis)
            {
                rastaPaskyra = paskyra;
            }
        }

        if (rastaPaskyra == null)
        {
            ViewBag.Klaida = "Prisijungti nepavyko: neteisingas el. paštas arba slaptažodis.";
            return View();
        }

        // Naudotojas prijungiamas ir pateikiamas pagrindinis langas
        Response.Cookies.Append("Role", rastaPaskyra.Role);
        return RedirectToAction("Index", "Home");
    }

    // Atsijungimas (3.14 pav.): sesija baigiama ir pateikiamas viešas pagrindinis langas
    [HttpPost]
    public IActionResult Atsijungti()
    {
        Response.Cookies.Delete("Role");
        return RedirectToAction("Index", "Home");
    }
}
