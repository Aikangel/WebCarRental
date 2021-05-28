using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebCarRental.Data;
using WebCarRental.Models;

namespace WebCarRental.Pages.FilReq.Fil
{
    public class Fil2Model : PageModel
    {
        private readonly WebCarRental.Data.CarRentalContext _context;

        public Fil2Model(WebCarRental.Data.CarRentalContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get; set; }
        public CarBrand CarBrand { get; set; }
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarBrand = _context.CarBrands.First(m => m.BrandCode == id);

            if (CarBrand == null)
            {
                return NotFound();
            }
            Car = await _context.Cars
                .Include(e => e.BrandCodeNavigation).Where(m => m.BrandCode == CarBrand.BrandCode).ToListAsync();
            return Page();
        }
    }
}