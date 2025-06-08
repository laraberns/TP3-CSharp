using CityBreaks.Web.Data;
using CityBreaks.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CityBreaks.Web.Pages
{
    public class EditPropertyModel : PageModel
    {
        private readonly CityBreaksContext _context;

        public EditPropertyModel(CityBreaksContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Property Property { get; set; }

        public SelectList CitiesSelectList { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Property = await _context.Properties
                .Include(p => p.City)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (Property == null)
            {
                return NotFound();
            }

            // Carrega cidades para dropdown
            var cities = await _context.Cities.OrderBy(c => c.Name).ToListAsync();
            CitiesSelectList = new SelectList(cities, "Id", "Name", Property.CityId);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var propertyToUpdate = await _context.Properties.FindAsync(id);

            if (propertyToUpdate == null)
            {
                return NotFound();
            }

            // Remover validação para a propriedade de navegação City, que não vem do formulário
            ModelState.Remove("Property.City");

            if (!await TryUpdateModelAsync<Property>(
                propertyToUpdate,
                "Property",
                p => p.Name,
                p => p.PricePerNight,
                p => p.CityId))
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                foreach (var err in errors)
                    Console.WriteLine("Erro de validação: " + err);

                // Recarrega cidades para dropdown em caso de erro
                var cities = await _context.Cities.OrderBy(c => c.Name).ToListAsync();
                CitiesSelectList = new SelectList(cities, "Id", "Name", propertyToUpdate.CityId);

                return Page();
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }

    }

}
