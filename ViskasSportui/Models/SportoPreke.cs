namespace ViskasSportui.Models
{
    public class SportoPreke
    {
        public int Id { get; set; }
        public string Pavadinimas { get; set; }
        public string Gamintojas { get; set; }
        public string Modelis { get; set; }
        public string Aprasymas { get; set; }
        public string Kategorija { get; set; }

    }
    public class PrekesPasiulymas
    {
        public int Id { get; set; }
        public double Kaina { get; set; }
        public string Nuoroda { get; set; }
        public DateTime SurinkimoData { get; set; }
        public Boolean Prieinama { get; set; }
    }
    public class  InternetineParduotuve
    {
        public string Pavadinimas { get; set; }
        public string SvetainesAdresas { get; set; }
        public string Aprasymas { get; set; }

    }
    public class  PrekesSavybe
    {
        public int Id { get; set; }
        public int PrekeId { get; set; }
        public string Pavadinimas { get; set; }
        public double Reiksme { get; set; }
        public string MatavimoVienetas { get; set; }
    }
}
