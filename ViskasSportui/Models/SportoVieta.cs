namespace ViskasSportui.Models;

// Esybė „Sporto vieta“ iš dalykinės srities modelio (3.25 pav.)
public class SportoVieta
{
    public int Id { get; set; }
    public string Pavadinimas { get; set; } = "";
    public string Aprasymas { get; set; } = "";
    public string Adresas { get; set; } = "";
    public double Platuma { get; set; }
    public double Ilguma { get; set; }
    public string Tipas { get; set; } = "";
}
