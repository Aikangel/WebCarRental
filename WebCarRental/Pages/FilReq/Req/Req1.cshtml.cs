using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebCarRental.Data;
using WebCarRental.Models;

namespace WebCarRental.Pages.FilReq.Req
{
    public class Req1Model : PageModel
    {
        private readonly WebCarRental.Data.CarRentalContext _context;

        public Req1Model(WebCarRental.Data.CarRentalContext context)
        {
            _context = context;
        }

        public IList<Staff> Staff { get; set; }
        public IList<Position> Position { get; set; }
        public async Task OnGetAsync()
        {
            Staff = await _context.Staff.ToListAsync();
            Position = await _context.Positions.ToListAsync();
        }
    }
}