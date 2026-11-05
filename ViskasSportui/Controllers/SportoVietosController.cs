using Microsoft.AspNetCore.Mvc;
using ViskasSportui.Models;

namespace ViskasSportui.Controllers;

// „Sporto vietų valdiklis“ (analizės diagramos 3.26–3.30).
// Prototipe duomenys tik rodomi: niekas neišsaugoma ir nešalinama.
public class SportoVietosController : Controller
{
    // Sporto vietų peržiūros langas: sąrašas, filtravimas ir pasirinktos vietos informacija (3.3 pav.).
    // Jei id = 0, sporto vieta dar nepasirinkta.
    public IActionResult Perziura(string pavadinimas, string tipas, int id)
    {
        // Atrenkamos vietos, atitinkančios filtrą. Tuščias filtro laukas reiškia „bet koks“.
        List<SportoVieta> vietos = new List<SportoVieta>();
        foreach (SportoVieta vieta in DemoDuomenys.SportoVietos)
        {
            bool tinkaPavadinimas = string.IsNullOrWhiteSpace(pavadinimas)
                || vieta.Pavadinimas.ToLower().Contains(pavadinimas.ToLower());
            bool tinkaTipas = string.IsNullOrWhiteSpace(tipas) || vieta.Tipas == tipas;

            if (tinkaPavadinimas && tinkaTipas)
            {
                vietos.Add(vieta);
            }
        }

        // Pasirinktos sporto vietos informacija
        if (id != 0)
        {
            SportoVieta pasirinkta = RastiVieta(id);
            if (pasirinkta == null)
            {
                ViewBag.Klaida = "Sporto vietos duomenų rasti nepavyko.";
            }
            ViewBag.Pasirinkta = pasirinkta;
        }

        ViewBag.Pavadinimas = pavadinimas;
        ViewBag.Tipas = tipas;
        return View("Perziura", vietos);
    }

    // Sporto vietos įvedimo langas (3.4 pav.).
    // Langas pats parodo, kad funkcija prieinama tik administratoriui.
    public IActionResult Ivesti()
    {
        return View(new SportoVieta());
    }

    [HttpPost]
    public IActionResult Ivesti(SportoVieta vieta)
    {
        // Įvesti gali tik administratorius. Kitiems langas parodo, kad funkcija neprieinama.
        if (Request.Cookies["Role"] != "Administratorius")
        {
            return View(vieta);
        }

        if (string.IsNullOrWhiteSpace(vieta.Pavadinimas))
        {
            ViewBag.Klaida = "Duomenys neteisingi: įveskite pavadinimą.";
        }
        else
        {
            ViewBag.Sekme = "Sporto vieta sėkmingai įvesta.";
        }
        return View(vieta);
    }

    // Sporto vietos redagavimo forma (3.5 pav.)
    public IActionResult Redaguoti(int id)
    {
        SportoVieta vieta = RastiVieta(id);
        if (vieta == null)
        {
            ViewBag.Klaida = "Sporto vietos duomenų rasti nepavyko.";
        }
        return View(vieta);
    }

    [HttpPost]
    public IActionResult Redaguoti(SportoVieta vieta)
    {
        // Redaguoti gali tik administratorius. Kitiems langas parodo, kad funkcija neprieinama.
        if (Request.Cookies["Role"] != "Administratorius")
        {
            return View(vieta);
        }

        if (string.IsNullOrWhiteSpace(vieta.Pavadinimas))
        {
            ViewBag.Klaida = "Duomenys neteisingi: įveskite pavadinimą.";
        }
        else
        {
            ViewBag.Sekme = "Sporto vieta sėkmingai paredaguota.";
        }
        return View(vieta);
    }

    // Šalinimas, kai šalinimo patvirtinimo lange paspaudžiamas „Patvirtinti“ (3.2 pav.).
    // Rezultatas parodomas peržiūros lange, kuriame buvo atidarytas patvirtinimo langas.
    [HttpPost]
    public IActionResult Salinti(int id)
    {
        // Šalinti gali tik administratorius
        if (Request.Cookies["Role"] != "Administratorius")
        {
            ViewBag.Klaida = "Funkcija prieinama tik administratoriui.";
            return Perziura("", "", 0);
        }

        SportoVieta vieta = RastiVieta(id);
        if (vieta == null)
        {
            ViewBag.Klaida = "Sporto vietos pašalinti nepavyko.";
        }
        else
        {
            ViewBag.Sekme = "Sporto vieta sėkmingai pašalinta.";
        }
        return Perziura("", "", 0);
    }

    // Vietos parinkimo ir maršruto sudarymo langas (3.6 pav., 3.30 pav.)
    public IActionResult Marsrutas()
    {
        return View();
    }

    // Kelių grafas dar nerealizuotas, todėl pasirinkus pradžios tašką
    // rodomas pastovus rezultatų ir maršrutų pavyzdys.
    [HttpPost]
    public IActionResult Marsrutas(string pradziosTaskas, string tipas, string prioritetas)
    {
        // Pasirinkimai paliekami formoje
        ViewBag.PradziosTaskas = pradziosTaskas;
        ViewBag.Tipas = tipas;
        ViewBag.Prioritetas = prioritetas;

        if (string.IsNullOrWhiteSpace(pradziosTaskas))
        {
            ViewBag.Klaida = "Duomenys neteisingi: pasirinkite pradžios tašką.";
        }
        return View();
    }

    // Suranda sporto vietą pagal Id. Jei tokios vietos nėra, grąžina null.
    private SportoVieta RastiVieta(int id)
    {
        foreach (SportoVieta vieta in DemoDuomenys.SportoVietos)
        {
            if (vieta.Id == id)
            {
                return vieta;
            }
        }
        return null;
    }
}
