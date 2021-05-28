using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebCarRental.Models
{
    public partial class CarBrand
    {
        [Display(Name = "Код марки")]
        public long BrandCode { get; set; }
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Технические характеристики")]
        public string TechnicalSpecifications { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
