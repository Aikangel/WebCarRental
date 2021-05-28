using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebCarRental.Pages.FilReq
{
    public class IndexModel : PageModel
    {
        private readonly WebCarRental.Data.CarRentalContext _context;

        public IndexModel(WebCarRental.Data.CarRentalContext context)
        {
            _context = context;
        }
        public List<SelectListItem> Position { get; set; }
        public List<SelectListItem> Brand { get; set; }

        public IActionResult OnGet()
        {
            Position = _context.Positions.Select(p =>
                new SelectListItem
                {
                    Value = p.PositionCode.ToString(),
                    Text = p.NameOfThePosition
                }).ToList();

            Brand = _context.CarBrands.Select(p =>
                new SelectListItem
                {
                    Value = p.BrandCode.ToString(),
                    Text = p.Name
                }).ToList();

            return Page();
        }

    }
}