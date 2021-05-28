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

namespace WebCarRental.Pages.AdditionalServices
{
    public class EditModel : PageModel
    {
        private readonly WebCarRental.Data.CarRentalContext _context;

        public EditModel(WebCarRental.Data.CarRentalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AdditionalService AdditionalService { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AdditionalService = await _context.AdditionalServices.FirstOrDefaultAsync(m => m.ServiceCode == id);

            if (AdditionalService == null)
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

            _context.Attach(AdditionalService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdditionalServiceExists(AdditionalService.ServiceCode))
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

        private bool AdditionalServiceExists(long id)
        {
            return _context.AdditionalServices.Any(e => e.ServiceCode == id);
        }
    }
}
