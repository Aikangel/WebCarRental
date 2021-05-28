using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebCarRental.Data;
using WebCarRental.Models;

namespace WebCarRental.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly WebCarRental.Data.CarRentalContext _context;

        public DetailsModel(WebCarRental.Data.CarRentalContext context)
        {
            _context = context;
        }

        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customers.FirstOrDefaultAsync(m => m.ClientCode == id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
