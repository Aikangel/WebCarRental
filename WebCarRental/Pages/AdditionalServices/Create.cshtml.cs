using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebCarRental.Data;
using WebCarRental.Models;

namespace WebCarRental.Pages.AdditionalServices
{
    public class CreateModel : PageModel
    {
        private readonly WebCarRental.Data.CarRentalContext _context;

        public CreateModel(WebCarRental.Data.CarRentalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AdditionalService AdditionalService { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AdditionalServices.Add(AdditionalService);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
