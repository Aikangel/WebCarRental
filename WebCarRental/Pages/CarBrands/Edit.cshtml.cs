using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCarRental.Data;
using WebCarRental.Models;

namespace WebCarRental.Pages.CarBrands
{
    public class EditModel : PageModel
    {
        private readonly WebCarRental.Data.CarRentalContext _context;

        public EditModel(WebCarRental.Data.CarRentalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CarBrand CarBrand { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarBrand = await _context.CarBrands.FirstOrDefaultAsync(m => m.BrandCode == id);

            if (CarBrand == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CarBrand).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarBrandExists(CarBrand.BrandCode))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CarBrandExists(long id)
        {
            return _context.CarBrands.Any(e => e.BrandCode == id);
        }
    }
}
