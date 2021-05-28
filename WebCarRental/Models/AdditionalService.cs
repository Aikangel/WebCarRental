using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebCarRental.Models
{
    public partial class AdditionalService
    {
        [Display(Name = "Код услуги")]
        public long ServiceCode { get; set; }
        [Display(Name = "Цена")]
        public long Price { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Наименование")]
        public string Title { get; set; }
    }
}
