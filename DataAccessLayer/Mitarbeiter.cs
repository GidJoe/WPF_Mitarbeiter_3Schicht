public class Mitarbeiter
{
    public int MID { get; set; }
    public string Vorname { get; set; }
    public string Nachname { get; set; }
    public string Geburtstag { get; set; } // Can also use DateTime if you plan to handle conversion
    public int Age { get; set; }
    public string Strasse { get; set; } // Note: It might be easier to avoid special characters in property names
    public string Hausnummer { get; set; }
    public double Urlaubstage { get; set; } // Using double for REAL datatype
    public int Krankheitstage { get; set; }
    public double Gehalt { get; set; } // Using double for REAL datatype
    public string Krankenkasse { get; set; }
    public string Parkplatz { get; set; }
    public string Steuerklasse { get; set; }
}