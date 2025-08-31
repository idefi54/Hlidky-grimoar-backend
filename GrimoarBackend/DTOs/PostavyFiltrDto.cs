namespace GrimoarBackend.DTOs
{
    public record class PostavyFiltrDto
    {
        public string? jmeno;
        public StranaEnum? strana;
        public SpecializaceEnum? specializace;
        public FrakceEnum? frakce;
        public int? kategorie;
    }
}
