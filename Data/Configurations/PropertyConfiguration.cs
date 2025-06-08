﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
        }
    }
}
