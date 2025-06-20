﻿using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CityBreaks.Web.Data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(c => c.CountryName)
                   .HasMaxLength(100)
                   .HasColumnName("CountryName");

            builder.Property(c => c.CountryCode)
                   .HasColumnName("CountryCode");

            builder.HasData(
    new Country { Id = 1, CountryCode = "PT", CountryName = "Portugal" },
    new Country { Id = 2, CountryCode = "ES", CountryName = "Espanha" }
);
        }
    }
}
