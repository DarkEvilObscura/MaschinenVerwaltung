using System;

namespace MaschinenVerwaltung
{
    public class Datensatz
    {
        public int Id { get; set; }
        public string Typ { get; set; }
        public string Gerätenummer { get; set; }
        public string Originalnummer { get; set; }
        public string Bemerkung { get; set; }
        public DateTime TÜV { get; set; }
        public bool NichtVorhanden { get; set; }
        public Options Options { get; set; }
        public string Wartungsprotokoll { get; set; }

        public Datensatz(int id, string typ, string gerätenummer, string originalnummer, string bemerkung, DateTime tüv, bool nichtVorhanden, Options options, string wartungsprotokoll)
        {
            this.Id = id;
            this.Typ = typ;
            this.Gerätenummer = gerätenummer;
            this.Originalnummer = originalnummer;
            this.Bemerkung = bemerkung;
            this.TÜV = tüv;
            this.NichtVorhanden = nichtVorhanden;
            this.Options = options;
            this.Wartungsprotokoll = wartungsprotokoll;
        }
    }
}
