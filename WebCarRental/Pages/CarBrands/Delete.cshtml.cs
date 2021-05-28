using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebCarRental.Data;
using WebCarRental.Models;

namespace WebCarRental.Pages.CarBrands
{
    public class DeleteModel : PageModel
    {
        private readonly WebCarRental.Data.CarRentalContext _context;

        public DeleteModel(WebCarRental.Data.CarRentalContext context)
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

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarBrand = await _context.CarBrands.FindAsync(id);

            if (CarBrand != null)
            {
                _context.CarBrands.Remove(CarBrand);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
