using CityBreaks.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IPropertyService
{
    Task<List<Property>> GetAllActivePropertiesAsync();

    Task<bool> DeleteAsync(int id);

    Task<List<Property>> GetFilteredAsync(decimal? minPrice, decimal? maxPrice, string cityName, string propertyName);
}
