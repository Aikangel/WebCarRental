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
    public class IndexModel : PageModel
    {
        private readonly WebCarRental.Data.CarRentalContext _context;

        public IndexModel(WebCarRental.Data.CarRentalContext context)
        {
            _context = context;
        }

        public IList<RentalService> RentalService { get;set; }

        public async Task OnGetAsync()
        {
            RentalService = await _context.RentalServices
                .Include(r => r.ClientCodeNavigation)
                .Include(r => r.VehicleCodeNavigation).ToListAsync();
        }
    }
}
