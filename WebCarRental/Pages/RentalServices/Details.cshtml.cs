using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebCarRental.Data;
using WebCarRental.Models;

namespace WebCarRental.Pages.RentalServices
{
    public class DetailsModel : PageModel
    {
        private readonly WebCarRental.Data.CarRentalContext _context;

        public DetailsModel(WebCarRental.Data.CarRentalContext context)
        {
            _context = context;
        }

        public RentalService RentalService { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RentalService = await _context.RentalServices
                .Include(r => r.ClientCodeNavigation)
                .Include(r => r.VehicleCodeNavigation).FirstOrDefaultAsync(m => m.ServicesId == id);

            if (RentalService == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
