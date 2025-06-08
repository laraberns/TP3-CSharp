using CityBreaks.Web.Data;
using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore;

public class PropertyService
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
}
