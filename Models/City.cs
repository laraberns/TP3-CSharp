namespace CityBreaks.Web.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Foreign Key
        public int CountryId { get; set; }

        // Navegação
        public Country Country { get; set; }

        // Navegação 1:N para Property
        public List<Property> Properties { get; set; } = new();

    }
}
