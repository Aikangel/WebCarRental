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
    public class Fil1Model : PageModel
    {
        private readonly WebCarRental.Data.CarRentalContext _context;

        public Fil1Model(WebCarRental.Data.CarRentalContext context)
        {
            _context = context;
        }

        public IList<Staff> Staff { get; set; }
        public Position Position { get; set; }
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Position = _context.Positions.First(m => m.PositionCode == id);

            if (Position == null)
            {
                return NotFound();
            }
            Staff = await _context.Staff
                .Include(e => e.PositionCodeNavigation).Where(m => m.PositionCode == Position.PositionCode).ToListAsync();
            return Page();
        }
    }
}