namespace ViskasSportui.Models;

// Esybė „Sporto renginys“ iš dalykinės srities modelio
public class SportoRenginys
{
    public int Id { get; set; }
    public string Pavadinimas { get; set; } = "";
    public string Aprasymas { get; set; } = "";
    public DateTime PradziosData { get; set; }
    public DateTime PabaigosData { get; set; }
    public string Vieta { get; set; } = "";

    // Ryšys su esybe „Sporto šaka“ (renginys priklauso šakai)
    public string SportoSaka { get; set; } = "";

    public bool JauIvyko()
    {
        return PabaigosData.Date < DateTime.Today;
    }
}

// Sporto renginių posistemės demonstraciniai duomenys.
// Laikomi atskirai nuo bendro DemoDuomenys, kad nesikirstų su kitų posistemių pakeitimais.
public static class RenginiuDemoDuomenys
{
    public static List<string> SportoSakos = new List<string>
    {
        "Krepšinis", "Futbolas", "Bėgimas", "Tenisas", "Plaukimas"
    };

    public static List<SportoRenginys> SportoRenginiai = new List<SportoRenginys>
    {
        new SportoRenginys { Id = 1, Pavadinimas = "Žalgiris – Rytas", SportoSaka = "Krepšinis",
            PradziosData = new DateTime(2026, 11, 20), PabaigosData = new DateTime(2026, 11, 20),
            Vieta = "Žalgirio arena", Aprasymas = "LKL reguliariojo sezono rungtynės." },
        new SportoRenginys { Id = 2, Pavadinimas = "Kauno kalėdinis bėgimas", SportoSaka = "Bėgimas",
            PradziosData = new DateTime(2026, 12, 13), PabaigosData = new DateTime(2026, 12, 13),
            Vieta = "Santakos parkas", Aprasymas = "5 ir 10 km bėgimo trasos visiems norintiems." },
        new SportoRenginys { Id = 3, Pavadinimas = "FK Kauno Žalgiris – Žalgiris Vilnius", SportoSaka = "Futbolas",
            PradziosData = new DateTime(2026, 11, 29), PabaigosData = new DateTime(2026, 11, 29),
            Vieta = "S. Dariaus ir S. Girėno stadionas", Aprasymas = "A lygos rungtynės." },
        new SportoRenginys { Id = 4, Pavadinimas = "Kauno teniso turnyras", SportoSaka = "Tenisas",
            PradziosData = new DateTime(2027, 1, 15), PabaigosData = new DateTime(2027, 1, 18),
            Vieta = "SEB arena", Aprasymas = "Mėgėjų teniso turnyras vienetų ir dvejetų kategorijose." },
        new SportoRenginys { Id = 5, Pavadinimas = "Rudens krepšinio taurė", SportoSaka = "Krepšinis",
            PradziosData = new DateTime(2026, 10, 10), PabaigosData = new DateTime(2026, 10, 12),
            Vieta = "Žalgirio arena", Aprasymas = "Jau įvykęs jaunimo krepšinio turnyras." },
    };

    // Demonstracinio registruoto naudotojo nustatymai ir peržiūros istorija rekomendacijoms
    public static List<string> NaudotojoMegstamosSakos = new List<string> { "Krepšinis", "Bėgimas" };
    public static List<int> NaudotojoPerziuretiRenginiai = new List<int> { 3 };
    public static string NaudotojoVieta = "KTU Studentų miestelis";
}
