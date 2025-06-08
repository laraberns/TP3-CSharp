using CityBreaks.Web.Models;
using CityBreaks.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityBreaks.Web.Pages
{
    public class CityDetailsModel : PageModel
    {
        private readonly ICityService _cityService;

        public CityDetailsModel(ICityService cityService)
        {
            _cityService = cityService;
        }

        public City City { get; set; }

        public async Task<IActionResult> OnGetAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return NotFound();

            var city = await _cityService.GetByNameAsync(name);

            if (city == null) return NotFound();

            City = city;
            return Page();
        }
    }
}
