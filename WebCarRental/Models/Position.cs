using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebCarRental.Models
{
    public partial class Position
    {
        public Position()
        {
            Staff = new HashSet<Staff>();
        }

        [Display(Name = "Код должности")]
        public long PositionCode { get; set; }
        [Display(Name = "Наименование")]
        public string NameOfThePosition { get; set; }
        [Display(Name = "Требования")]
        public string Requirements { get; set; }
        [Display(Name = "Оклад")]
        public long Salary { get; set; }
        [Display(Name = "Обязанности")]
        public string Responsibilities { get; set; }

        public virtual ICollection<Staff> Staff { get; set; }
    }
}
