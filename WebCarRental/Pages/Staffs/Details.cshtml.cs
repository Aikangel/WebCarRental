using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebCarRental.Data;
using WebCarRental.Models;

namespace WebCarRental.Pages.Staffs
{
    public class DetailsModel : PageModel
    {
        private readonly WebCarRental.Data.CarRentalContext _context;

        public DetailsModel(WebCarRental.Data.CarRentalContext context)
        {
            _context = context;
        }

        public Staff Staff { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Staff = await _context.Staff
                .Include(s => s.PositionCodeNavigation).FirstOrDefaultAsync(m => m.EmployeeCode == id);

            if (Staff == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
