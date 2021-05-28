using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebCarRental.Data;
using WebCarRental.Models;

namespace WebCarRental.Pages.Cars
{
    public class DetailsModel : PageModel
    {
        private readonly WebCarRental.Data.CarRentalContext _context;

        public DetailsModel(WebCarRental.Data.CarRentalContext context)
        {
            _context = context;
        }

        public Car Car { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _context.Cars
                .Include(c => c.EmployeeCodeNavigation).FirstOrDefaultAsync(m => m.VehicleCode == id);

            if (Car == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
