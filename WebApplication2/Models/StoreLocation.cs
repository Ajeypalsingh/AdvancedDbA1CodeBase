namespace WebApplication2.Models
{
    public class StoreLocation
    {
        public Guid StoreNumber { get; set; }
        public string StreetNameNumber { get; set; }
        public CanadianProvince CanadianProvince { get; set; }
        public HashSet<StoreLaptop> storeLaptops { get; set; } = new HashSet<StoreLaptop>();
    }

    public enum CanadianProvince
    {
        Alberta,
        BritishColumbia,
        Manitoba,
        NewBrunswick,
        NewfoundlandAndLabrador,
        NovaScotia,
        Ontario,
        PrinceEdwardIsland,
        Quebec,
        Saskatchewan,
        NorthwestTerritories,
        Nunavut,
        Yukon
    }
}
