namespace CityBreaks.Web.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PricePerNight { get; set; }

        public DateTime? DeletedAt { get; set; }

        // Foreign Key
        public int CityId { get; set; }

        // Navegação
        public City? City { get; set; }
    }
}
