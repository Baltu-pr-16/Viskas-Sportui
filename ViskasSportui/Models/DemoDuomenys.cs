namespace ViskasSportui.Models;

// Demonstraciniai duomenys GUI prototipui.
// Duomenų bazės dar nėra, todėl sąrašai saugomi tiesiog kode ir niekada nekeičiami.
public static class DemoDuomenys
{
    public static List<string> Tipai = new List<string>
    {
        "Arena", "Stadionas", "Sporto salė", "Baseinas", "Parkas", "Teniso kortai"
    };

    public static List<SportoVieta> SportoVietos = new List<SportoVieta>
    {
        new SportoVieta { Id = 1, Pavadinimas = "Žalgirio arena", Tipas = "Arena",
            Adresas = "Karaliaus Mindaugo pr. 50, Kaunas", Platuma = 54.8905, Ilguma = 23.9146,
            Aprasymas = "Daugiafunkcė arena krepšinio rungtynėms ir sporto renginiams." },
        new SportoVieta { Id = 2, Pavadinimas = "S. Dariaus ir S. Girėno stadionas", Tipas = "Stadionas",
            Adresas = "Perkūno al. 5, Kaunas", Platuma = 54.8977, Ilguma = 23.9343,
            Aprasymas = "Futbolo ir lengvosios atletikos stadionas." },
        new SportoVieta { Id = 3, Pavadinimas = "Santakos parkas", Tipas = "Parkas",
            Adresas = "Santakos parkas, Kaunas", Platuma = 54.8975, Ilguma = 23.8835,
            Aprasymas = "Pasivaikščiojimo ir bėgimo takai prie Nemuno ir Neries santakos." },
    };

    // Pradžios taškai maršrutui
    public static List<string> PradziosTaskai = new List<string>
    {
        "KTU Studentų miestelis", "Kauno centras (Laisvės alėja)", "Kauno autobusų stotis", "Vilijampolė"
    };

    // Demonstracinės paskyros prisijungimui. Rolės atitinka „NaudotojoRole“ reikšmes.
    public static List<DemoPaskyra> Paskyros = new List<DemoPaskyra>
    {
        new DemoPaskyra { ElPastas = "admin@viskassportui.lt", Slaptazodis = "admin123", Role = "Administratorius" },
        new DemoPaskyra { ElPastas = "naudotojas@viskassportui.lt", Slaptazodis = "naudotojas123", Role = "Registruotas" },
    };
    public static List<string> PrekiuKategorijos = new List<string>
    {
        "Krepšinis", "Futbolas", "Bėgimas", "Fitnesas ir Gym", "Tenisas"
    };

    public static List<SportoPreke> SportoPrekes = new List<SportoPreke>
    {
        new SportoPreke
        {
            Id = 1,
            Pavadinimas = "Krepšinio kamuolys TF-1000",
            Gamintojas = "Spalding",
            Modelis = "Precision Euroleague",
            Aprasymas = "Aukščiausios kokybės kompozitinės odos kamuolys, skirtas varžyboms patalpose.",
            Kategorija = "Krepšinis"
        },
        new SportoPreke
        {
            Id = 2,
            Pavadinimas = "Bėgimo bateliai Pegasus 40",
            Gamintojas = "Nike",
            Modelis = "Air Zoom Pegasus 40",
            Aprasymas = "Universalūs bėgimo bateliai su puikia amortizacija kasdienėms treniruotėms.",
            Kategorija = "Bėgimas"
        },
        new SportoPreke
        {
            Id = 3,
            Pavadinimas = "Futbolo kamuolys Al Rihla",
            Gamintojas = "Adidas",
            Modelis = "Pro World Cup",
            Aprasymas = "Oficialus begarsis ir besiūlis varžybų kamuolys su „Thermal Bonding“ technologija.",
            Kategorija = "Futbolas"
        },
        new SportoPreke
        {
            Id = 4,
            Pavadinimas = "Teniso raketė Pure Drive",
            Gamintojas = "Babolat",
            Modelis = "Pure Drive 2023",
            Aprasymas = "Populiari raketė, suteikianti papildomą galią ir sukimą smūgio metu.",
            Kategorija = "Tenisas"
        }
    };

    public static List<InternetineParduotuve> Parduotuves = new List<InternetineParduotuve>
    {
        new InternetineParduotuve
        {
            Pavadinimas = "Sportland",
            SvetainesAdresas = "https://www.sportland.lt",
            Aprasymas = "Didžiausias sporto prekių tinklas Baltijos šalyse."
        },
        new InternetineParduotuve
        {
            Pavadinimas = "Decathlon",
            SvetainesAdresas = "https://www.decathlon.lt",
            Aprasymas = "Platus laisvalaikio ir sporto inventoriaus pasirinkimas už prieinamą kainą."
        },
        new InternetineParduotuve
        {
            Pavadinimas = "Fansurf / Sporto Meistras",
            SvetainesAdresas = "https://www.sportomeistras.lt",
            Aprasymas = "Specializuota profesionalaus sporto inventoriaus parduotuvė."
        }
    };

    public static List<PrekesPasiulymas> Pasiulymai = new List<PrekesPasiulymas>
    {
        new PrekesPasiulymas
        {
            Id = 1,
            Kaina = 89.99,
            Nuoroda = "https://www.sportland.lt/preke/spalding-tf-1000",
            SurinkimoData = new DateTime(2026, 3, 1),
            Prieinama = true
        },
        new PrekesPasiulymas
        {
            Id = 2,
            Kaina = 79.50,
            Nuoroda = "https://www.sportomeistras.lt/krepsinis/tf1000",
            SurinkimoData = new DateTime(2026, 3, 2),
            Prieinama = true
        },
        new PrekesPasiulymas
        {
            Id = 3,
            Kaina = 139.99,
            Nuoroda = "https://www.sportland.lt/preke/nike-pegasus-40",
            SurinkimoData = new DateTime(2026, 3, 3),
            Prieinama = true
        },
        new PrekesPasiulymas
        {
            Id = 4,
            Kaina = 119.00,
            Nuoroda = "https://www.decathlon.lt/pegasus-40-running",
            SurinkimoData = new DateTime(2026, 2, 25),
            Prieinama = false // Išparduota
        }
    };

    public static List<PrekesSavybe> Savybes = new List<PrekesSavybe>
{
    // Krepšinio kamuolio TF-1000 (PrekeId = 1) savybės
    new PrekesSavybe { Id = 1, PrekeId = 1, Pavadinimas = "Svoris", Reiksme = 620, MatavimoVienetas = "g" },
    new PrekesSavybe { Id = 2, PrekeId = 1, Pavadinimas = "Dydis", Reiksme = 7, MatavimoVienetas = "dydis" },
    new PrekesSavybe { Id = 3, PrekeId = 1, Pavadinimas = "Slėgis", Reiksme = 0.6, MatavimoVienetas = "bar" },

    // Bėgimo batelių Pegasus 40 (PrekeId = 2) savybės
    new PrekesSavybe { Id = 4, PrekeId = 2, Pavadinimas = "Svoris", Reiksme = 285, MatavimoVienetas = "g" },
    new PrekesSavybe { Id = 5, PrekeId = 2, Pavadinimas = "Pado nuolydis (drop)", Reiksme = 10, MatavimoVienetas = "mm" },
    new PrekesSavybe { Id = 6, PrekeId = 2, Pavadinimas = "Dydis (EU)", Reiksme = 43, MatavimoVienetas = "dydis" },

    // Futbolo kamuolio Al Rihla (PrekeId = 3) savybės
    new PrekesSavybe { Id = 7, PrekeId = 3, Pavadinimas = "Svoris", Reiksme = 430, MatavimoVienetas = "g" },
    new PrekesSavybe { Id = 8, PrekeId = 3, Pavadinimas = "Dydis", Reiksme = 5, MatavimoVienetas = "dydis" },

    // Teniso raketės Pure Drive (PrekeId = 4) savybės
    new PrekesSavybe { Id = 9, PrekeId = 4, Pavadinimas = "Svoris", Reiksme = 300, MatavimoVienetas = "g" },
    new PrekesSavybe { Id = 10, PrekeId = 4, Pavadinimas = "Lanko plotas", Reiksme = 645, MatavimoVienetas = "cm²" },
    new PrekesSavybe { Id = 11, PrekeId = 4, Pavadinimas = "Balansas", Reiksme = 320, MatavimoVienetas = "mm" }
};
}

public class DemoPaskyra
{
    public string ElPastas { get; set; } = "";
    public string Slaptazodis { get; set; } = "";
    public string Role { get; set; } = "";
}
