using Microsoft.AspNetCore.Mvc;
using ViskasSportui.Models;

namespace ViskasSportui.Controllers;

// Sporto renginių posistemė: „Renginių valdymo valdiklis“, „Renginių peržiūros valdiklis“
// ir „Renginių rekomendavimo valdiklis“ iš analizės klasių diagramų.
// Prototipe duomenys tik rodomi: niekas neišsaugoma ir nešalinama.
public class SportoRenginiaiController : Controller
{
    // ---------- Renginio peržiūra ----------

    // Renginių peržiūros langas: artėjančių renginių sąrašas
    public IActionResult Perziura()
    {
        List<SportoRenginys> artejantys = new List<SportoRenginys>();
        foreach (SportoRenginys renginys in RenginiuDemoDuomenys.SportoRenginiai)
        {
            if (!renginys.JauIvyko())
            {
                artejantys.Add(renginys);
            }
        }
        artejantys.Sort((a, b) => a.PradziosData.CompareTo(b.PradziosData));
        return View(artejantys);
    }

    // Renginio informacijos langas
    public IActionResult Informacija(int id)
    {
        SportoRenginys renginys = RastiRengini(id);
        if (renginys == null)
        {
            ViewBag.Klaida = "Renginys nerastas.";
        }
        return View(renginys);
    }

    // Renginio pažymėjimas kaip dominančio (pridedamas į naudotojo favoritus)
    [HttpPost]
    public IActionResult PazymetiDominanti(int id)
    {
        SportoRenginys renginys = RastiRengini(id);

        if (Request.Cookies["Role"] != "Registruotas")
        {
            ViewBag.Klaida = "Funkcija prieinama tik registruotam naudotojui.";
        }
        else if (renginys != null)
        {
            ViewBag.Sekme = "Renginys pridėtas į jūsų favoritus.";
        }
        return View("Informacija", renginys);
    }

    // ---------- Renginių rekomendavimas ----------

    // Renginių rekomendacijų langas.
    // zemelapiai = "nepasiekiama" leidžia parodyti atvejį, kai žemėlapių sistema neatsako.
    public IActionResult Rekomendacijos(string zemelapiai)
    {
        if (Request.Cookies["Role"] != "Registruotas")
        {
            return View(new List<RenginioRekomendacija>());
        }

        bool sistemaPasiekiama = zemelapiai != "nepasiekiama";

        // Atrenkami artėjantys renginiai pagal naudotojo nustatymus ir peržiūros istoriją
        List<RenginioRekomendacija> rekomendacijos = new List<RenginioRekomendacija>();
        foreach (SportoRenginys renginys in RenginiuDemoDuomenys.SportoRenginiai)
        {
            bool megstamaSaka = RenginiuDemoDuomenys.NaudotojoMegstamosSakos.Contains(renginys.SportoSaka);
            bool perziuretas = RenginiuDemoDuomenys.NaudotojoPerziuretiRenginiai.Contains(renginys.Id);

            if (!renginys.JauIvyko() && (megstamaSaka || perziuretas))
            {
                rekomendacijos.Add(new RenginioRekomendacija
                {
                    Renginys = renginys,
                    Kelione = ZemelapiuSistemosSasaja.UzklaustiAtstumo(
                        RenginiuDemoDuomenys.NaudotojoVieta, renginys.Vieta, sistemaPasiekiama)
                });
            }
        }

        // Surikiuojama pagal atitikimą: kai žinomi atstumai – artimiausi pirmi, kitaip – pagal datą
        if (sistemaPasiekiama)
        {
            rekomendacijos.Sort((a, b) => Atstumas(a).CompareTo(Atstumas(b)));
        }
        else
        {
            rekomendacijos.Sort((a, b) => a.Renginys.PradziosData.CompareTo(b.Renginys.PradziosData));
        }

        ViewBag.SistemaPasiekiama = sistemaPasiekiama;
        return View(rekomendacijos);
    }

    // ---------- Renginių valdymas (administratorius) ----------

    // Renginių valdymo langas: visų renginių sąrašas redagavimui ir šalinimui
    public IActionResult Valdymas()
    {
        return View(RenginiuDemoDuomenys.SportoRenginiai);
    }

    // Šalinimas, kai šalinimo patvirtinimo lange paspaudžiamas „Patvirtinti“
    [HttpPost]
    public IActionResult Salinti(List<int> pazymeti)
    {
        if (Request.Cookies["Role"] != "Administratorius")
        {
            ViewBag.Klaida = "Funkcija prieinama tik administratoriui.";
        }
        else if (pazymeti == null || pazymeti.Count == 0)
        {
            ViewBag.Klaida = "Nepažymėtas nė vienas renginys.";
        }
        else
        {
            ViewBag.Sekme = "Sėkmingai pašalinta renginių: " + pazymeti.Count + ".";
        }
        return View("Valdymas", RenginiuDemoDuomenys.SportoRenginiai);
    }

    // Renginio duomenų įvedimo langas
    public IActionResult Ivesti()
    {
        SportoRenginys naujas = new SportoRenginys();
        naujas.PradziosData = DateTime.Today;
        naujas.PabaigosData = DateTime.Today;
        return View(naujas);
    }

    [HttpPost]
    public IActionResult Ivesti(SportoRenginys renginys)
    {
        if (Request.Cookies["Role"] != "Administratorius")
        {
            return View(renginys);
        }

        string klaida = TikrintiDuomenis(renginys);
        if (klaida != null)
        {
            ViewBag.Klaida = klaida;
        }
        else
        {
            ViewBag.Sekme = "Sporto renginys sėkmingai įvestas.";
        }
        return View(renginys);
    }

    // Renginio redagavimo langas
    public IActionResult Redaguoti(int id)
    {
        SportoRenginys renginys = RastiRengini(id);
        if (renginys == null)
        {
            ViewBag.Klaida = "Renginio duomenų rasti nepavyko.";
        }
        return View(renginys);
    }

    // Išsaugoma, kai redagavimo patvirtinimo lange paspaudžiamas „Patvirtinti“
    [HttpPost]
    public IActionResult Redaguoti(SportoRenginys renginys)
    {
        if (Request.Cookies["Role"] != "Administratorius")
        {
            return View(renginys);
        }

        string klaida = TikrintiDuomenis(renginys);
        if (klaida != null)
        {
            ViewBag.Klaida = klaida;
        }
        else
        {
            ViewBag.Sekme = "Sporto renginys sėkmingai paredaguotas.";
        }
        return View(renginys);
    }

    // ---------- Pagalbiniai metodai ----------

    // Grąžina klaidos pranešimą arba null, jei duomenys teisingi
    private string TikrintiDuomenis(SportoRenginys renginys)
    {
        if (string.IsNullOrWhiteSpace(renginys.Pavadinimas) || string.IsNullOrWhiteSpace(renginys.SportoSaka))
        {
            return "Duomenys neteisingi: įveskite pavadinimą ir pasirinkite sporto šaką.";
        }
        if (renginys.PabaigosData < renginys.PradziosData)
        {
            return "Duomenys neteisingi: pabaigos data negali būti ankstesnė už pradžios datą.";
        }
        return null;
    }

    private SportoRenginys RastiRengini(int id)
    {
        foreach (SportoRenginys renginys in RenginiuDemoDuomenys.SportoRenginiai)
        {
            if (renginys.Id == id)
            {
                return renginys;
            }
        }
        return null;
    }

    private static double Atstumas(RenginioRekomendacija rekomendacija)
    {
        if (rekomendacija.Kelione == null)
        {
            return double.MaxValue;
        }
        return rekomendacija.Kelione.AtstumasKm;
    }
}
