using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CityBreaks.Web.Models;

namespace CityBreaks.Web.Data.Configurations
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.Property(p => p.Name)
                   .HasMaxLength(150)
                   .HasColumnName("PropertyName");

            builder.Property(p => p.PricePerNight)
                   .HasColumnName("PricePerNight");

            builder.HasData(
    new Property { Id = 1, Name = "Casa Alfama", PricePerNight = 85.50m, CityId = 1 },
    new Property { Id = 2, Name = "Ribeira Flat", PricePerNight = 70.00m, CityId = 2 },
    new Property { Id = 3, Name = "Gran Via Loft", PricePerNight = 120.00m, CityId = 3 }
);

        }
    }
}
