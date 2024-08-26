namespace GrimoarBackend.DTOs
{
    public record class PostavaZakladDto
    {
        public long id;
        public string jmeno;
        public string prijmeni;
        public string prezdivka;
        public string sereJmeno;
        public StranaEnum strana;
        public SpecializaceEnum specializace;
        public FrakceEnum frakce;
        public long kategorie;
        public long strop;
        public bool stropDosazen;
        public long pocetExpuCelkem;
        public long pocetVolnychExpu;
        public string kdoJeKdo;
        public string povidaSe;
        public string biografie;

    }
}
