using Microsoft.AspNetCore.Mvc;
using ViskasSportui.Models;

namespace ViskasSportui.Controllers
{
    public class SportoPrekesController : Controller
    {
        public IActionResult Perziura(string? kategorija, string? paieska)
        {
            var prekes = DemoDuomenys.SportoPrekes.AsEnumerable();

            // Filtravimas pagal pasirinktą kategoriją
            if (!string.IsNullOrEmpty(kategorija))
            {
                prekes = prekes.Where(p => p.Kategorija.Equals(kategorija, StringComparison.OrdinalIgnoreCase));
            }

            // Paieška pagal pavadinimą arba gamintoją
            if (!string.IsNullOrEmpty(paieska))
            {
                prekes = prekes.Where(p => p.Pavadinimas.Contains(paieska, StringComparison.OrdinalIgnoreCase) ||
                                           p.Gamintojas.Contains(paieska, StringComparison.OrdinalIgnoreCase));
            }

            // Perduodame duomenis vaizdui (View) išlaikydami pasirinktus filtrus
            ViewBag.Kategorijos = DemoDuomenys.PrekiuKategorijos;
            ViewBag.EsamaKategorija = kategorija;
            ViewBag.EsamaPaieska = paieska;

            return View(prekes.ToList());
        }

        // 2. Vienos konkrečios prekės išsamios informacijos peržiūra
        public IActionResult PrekesInfo(int id)
        {
            var preke = DemoDuomenys.SportoPrekes.FirstOrDefault(p => p.Id == id);

            if (preke == null)
            {
                return NotFound();
            }

            // Prijungiame susijusius pasiūlymus iš demo duomenų
            ViewBag.Pasiulymai = DemoDuomenys.Pasiulymai;
            ViewBag.Savybes = DemoDuomenys.Savybes;

            return View(preke);
        }
        public IActionResult Redaguoti(int id)
        {
            // Tikriname naudotojo rolę iš slapuko
            string? role = Request.Cookies["Role"];
            if (role != "Administratorius")
            {
                // Jei ne administratorius – nukreipiame atgal į sąrašą arba grąžiname klaidos puslapį
                return Unauthorized("Prieiga uždrausta. Redaguoti prekes gali tik Administratorius.");
            }

            var preke = DemoDuomenys.SportoPrekes.FirstOrDefault(p => p.Id == id);
            if (preke == null)
            {
                return NotFound();
            }

            return View(preke);
        }

        // ----------------------------------------------------
        // REDAGAVIMAS (POST): Išsaugoti pakeitimus
        // ----------------------------------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Redaguoti(int id, SportoPreke preke)
        {
            // Tikriname naudotojo rolę iš slapuko ir POST užklausos metu (apsaugai nuo tiesioginių užklausų)
            string? role = Request.Cookies["Role"];
            if (role != "Administratorius")
            {
                return Unauthorized("Prieiga uždrausta. Redaguoti prekes gali tik Administratorius.");
            }

            var esamaPreke = DemoDuomenys.SportoPrekes.FirstOrDefault(p => p.Id == id);
            if (esamaPreke == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Atnaujinami duomenys demo sąraše
                esamaPreke.Pavadinimas = preke.Pavadinimas;
                esamaPreke.Gamintojas = preke.Gamintojas;
                esamaPreke.Modelis = preke.Modelis;
                esamaPreke.Aprasymas = preke.Aprasymas;
                esamaPreke.Kategorija = preke.Kategorija;

                return RedirectToAction(nameof(Perziura));
            }

            return View(preke);
        }
        public IActionResult Istrinti(int id)
        {
            // Tikriname naudotojo rolę iš slapuko
            string? role = Request.Cookies["Role"];
            if (role != "Administratorius")
            {
                return Unauthorized("Prieiga uždrausta. Šalinti prekes gali tik Administratorius.");
            }

            var preke = DemoDuomenys.SportoPrekes.FirstOrDefault(p => p.Id == id);
            if (preke == null)
            {
                return NotFound();
            }

            return View(preke);
        }

        // ----------------------------------------------------
        // ŠALINIMAS (POST): Tikrasis prekės ištrynimas
        // ----------------------------------------------------
        [HttpPost, ActionName("Istrinti")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Tikriname naudotojo rolę iš slapuko ir POST užklausos metu
            string? role = Request.Cookies["Role"];
            if (role != "Administratorius")
            {
                return Unauthorized("Prieiga uždrausta. Šalinti prekes gali tik Administratorius.");
            }

            var preke = DemoDuomenys.SportoPrekes.FirstOrDefault(p => p.Id == id);
            if (preke != null)
            {
                DemoDuomenys.SportoPrekes.Remove(preke);
            }

            return RedirectToAction(nameof(Perziura));
        }
        public IActionResult Sukurti()
        {
            // Tikriname naudotojo rolę iš slapuko
            string? role = Request.Cookies["Role"];
            if (role != "Administratorius")
            {
                return Unauthorized("Prieiga uždrausta. Pridėti naujas prekes gali tik Administratorius.");
            }

            return View();
        }

        // ----------------------------------------------------
        // SUKŪRIMAS (POST): Įrašyti naują prekę į demo sąrašą
        // ----------------------------------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Sukurti(SportoPreke preke)
        {
            // Tikriname naudotojo rolę iš slapuko ir POST užklausos metu
            string? role = Request.Cookies["Role"];
            if (role != "Administratorius")
            {
                return Unauthorized("Prieiga uždrausta. Pridėti naujas prekes gali tik Administratorius.");
            }

            if (ModelState.IsValid)
            {
                // Sugeneruojame naują ID demo sąrašui
                preke.Id = DemoDuomenys.SportoPrekes.Any() ? DemoDuomenys.SportoPrekes.Max(p => p.Id) + 1 : 1;
                DemoDuomenys.SportoPrekes.Add(preke);

                return RedirectToAction(nameof(Perziura));
            }

            return View(preke);
        }
        // GET: Rodyti pasiūlymų paieškos formą su užpildyta prekės informacija
        public IActionResult PrekesPasiulymoPaieskosForma(int? id)
        {
            var preke = new SportoPreke();

            if (id.HasValue)
            {
                var rastaPreke = DemoDuomenys.SportoPrekes.FirstOrDefault(p => p.Id == id.Value);
                if (rastaPreke != null)
                {
                    preke = rastaPreke;
                }
            }

            ViewBag.Kategorijos = DemoDuomenys.PrekiuKategorijos;
            return View(preke);
        }

        // POST: Paleisti atrinkimą ir atidaryti pasiūlymų sąrašą
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult VykdytiPasiulymuPaieska(SportoPreke preke)
        {
            // Imituojamas pasiūlymų atrinkimas iš internetinių parduotuvių
            var pasiulytosPrekes = DemoDuomenys.Pasiulymai;

            ViewBag.IeskotaPreke = preke;
            ViewBag.Parduotuves = DemoDuomenys.Parduotuves;

            return View("Pasiulymai", pasiulytosPrekes);
        }

        // GET: Tiesioginis pasiūlymų peržiūros langas
        public IActionResult Pasiulymai()
        {
            ViewBag.Parduotuves = DemoDuomenys.Parduotuves;
            return View(DemoDuomenys.Pasiulymai);
        }
        public IActionResult PaieskosFiltrai()
        {
            ViewBag.Savybes = DemoDuomenys.Savybes;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult VykdytiFiltravima(string? savybesPavadinimas, double? minReiksme, double? maxReiksme)
        {
            var prekes = DemoDuomenys.SportoPrekes.AsEnumerable();

            if (!string.IsNullOrEmpty(savybesPavadinimas))
            {
                // Surandame prekės ID, kurios tenkina savybės kriterijus
                var atitinkanciuPrekiuId = DemoDuomenys.Savybes
                    .Where(s => s.Pavadinimas.Equals(savybesPavadinimas, StringComparison.OrdinalIgnoreCase))
                    .Where(s => (!minReiksme.HasValue || s.Reiksme >= minReiksme.Value) &&
                                (!maxReiksme.HasValue || s.Reiksme <= maxReiksme.Value))
                    .Select(s => s.PrekeId)
                    .ToList();

                // Atfiltruojame prekes
                prekes = prekes.Where(p => atitinkanciuPrekiuId.Contains(p.Id));
            }

            ViewBag.Kategorijos = DemoDuomenys.PrekiuKategorijos;
            ViewBag.FiltruotaPagalSavybe = savybesPavadinimas;

            return View("Perziura", prekes.ToList());
        }
    }
}
