using CityBreaks.Web.Data;
using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore;

public class PropertyService : IPropertyService
{
    private readonly CityBreaksContext _context;

    public PropertyService(CityBreaksContext context)
    {
        _context = context;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var property = await _context.Properties.FindAsync(id);
        if (property == null)
            return false;

        property.DeletedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Property>> GetAllActivePropertiesAsync()
    {
        return await _context.Properties
            .Where(p => p.DeletedAt == null)
            .Include(p => p.City)
            .ToListAsync();
    }

    public async Task<List<Property>> GetFilteredAsync(decimal? minPrice, decimal? maxPrice, string cityName, string propertyName)
    {
        IQueryable<Property> query = _context.Properties
            .Include(p => p.City)
            .Where(p => p.DeletedAt == null);

        if (minPrice.HasValue)
            query = query.Where(p => p.PricePerNight >= minPrice.Value);

        if (maxPrice.HasValue)
            query = query.Where(p => p.PricePerNight <= maxPrice.Value);

        if (!string.IsNullOrWhiteSpace(cityName))
            query = query.Where(p => p.City.Name.Contains(cityName));

        if (!string.IsNullOrWhiteSpace(propertyName))
            query = query.Where(p => p.Name.Contains(propertyName));

        return await query.ToListAsync();
    }
}
