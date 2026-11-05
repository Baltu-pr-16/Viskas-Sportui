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
}

public class DemoPaskyra
{
    public string ElPastas { get; set; } = "";
    public string Slaptazodis { get; set; } = "";
    public string Role { get; set; } = "";
}
