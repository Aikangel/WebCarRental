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

namespace WebCarRental.Pages.RentalServices
{
    public class EditModel : PageModel
    {
        private readonly WebCarRental.Data.CarRentalContext _context;

        public EditModel(WebCarRental.Data.CarRentalContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["ClientCode"] = new SelectList(_context.Customers, "ClientCode", "Address");
           ViewData["VehicleCode"] = new SelectList(_context.Cars, "VehicleCode", "EngineNumber");
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

            _context.Attach(RentalService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentalServiceExists(RentalService.ServicesId))
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

        private bool RentalServiceExists(long id)
        {
            return _context.RentalServices.Any(e => e.ServicesId == id);
        }
    }
}
