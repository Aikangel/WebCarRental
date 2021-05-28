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
    public class Req2Model : PageModel
    {
        private readonly WebCarRental.Data.CarRentalContext _context;

        public Req2Model(WebCarRental.Data.CarRentalContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get; set; }
        public IList<CarBrand> CarBrand { get; set; }
        public IList<Staff> Staff { get; set; }
        public async Task OnGetAsync()
        {
            Car = await _context.Cars.ToListAsync();
            CarBrand = await _context.CarBrands.ToListAsync();
            Staff = await _context.Staff.ToListAsync();
        }
    }
}