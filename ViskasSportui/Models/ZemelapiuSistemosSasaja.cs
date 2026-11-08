namespace ViskasSportui.Models;

// „Žemėlapių sistemos sąsaja“ (boundary klasė išorinei sistemai iš analizės diagramos).
// Prototipe tikra žemėlapių sistema nekviečiama: atstumai imami iš pastovios lentelės.
public static class ZemelapiuSistemosSasaja
{
    private static Dictionary<string, KelionesDuomenys> atstumai = new Dictionary<string, KelionesDuomenys>
    {
        { "Žalgirio arena", new KelionesDuomenys { AtstumasKm = 3.4, TrukmeMin = 11 } },
        { "Santakos parkas", new KelionesDuomenys { AtstumasKm = 5.1, TrukmeMin = 16 } },
        { "S. Dariaus ir S. Girėno stadionas", new KelionesDuomenys { AtstumasKm = 1.8, TrukmeMin = 7 } },
        { "SEB arena", new KelionesDuomenys { AtstumasKm = 4.6, TrukmeMin = 14 } },
    };

    // Grąžina atstumą ir kelionės trukmę iki vietos.
    // Jei sistema nepasiekiama, grąžina null.
    public static KelionesDuomenys UzklaustiAtstumo(string naudotojoVieta, string renginioVieta, bool sistemaPasiekiama)
    {
        if (!sistemaPasiekiama || !atstumai.ContainsKey(renginioVieta))
        {
            return null;
        }
        return atstumai[renginioVieta];
    }
}

public class KelionesDuomenys
{
    public double AtstumasKm { get; set; }
    public int TrukmeMin { get; set; }
}

// Vienas rekomendacijų sąrašo įrašas: renginys ir kelionė iki jo (null, jei atstumas nežinomas)
public class RenginioRekomendacija
{
    public SportoRenginys Renginys { get; set; }
    public KelionesDuomenys Kelione { get; set; }
}
