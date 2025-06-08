using CityBreaks.Web.Data;
using CityBreaks.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CityBreaks.Web.Pages
{
    public class CreatePropertyModel : PageModel
    {
        private readonly CityBreaksContext _context;

        public CreatePropertyModel(CityBreaksContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Property Property { get; set; }

        public SelectList CitySelectList { get; set; }

        public async Task OnGetAsync()
        {
            var cities = await _context.Cities
                .Include(c => c.Country)
                .ToListAsync();

            CitySelectList = new SelectList(
                cities,
                nameof(City.Id),
                nameof(City.Name));
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _context.Properties.AddAsync(Property);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}