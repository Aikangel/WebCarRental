using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebCarRental.Models
{
    public partial class Customer
    {
        public Customer()
        {
            RentalServices = new HashSet<RentalService>();
        }

        [Display(Name = "Код клиента")]
        public long ClientCode { get; set; }
        [Display(Name = "ФИО")]
        public string FullName { get; set; }
        [Display(Name = "Пол")]
        public string Paul { get; set; }
        [Display(Name = "Дата рождения")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Адрес")]
        public string Address { get; set; }
        [Display(Name = "Телефон")]
        public long Phone { get; set; }
        [Display(Name = "Паспортные данные")]
        public long PassportDetails { get; set; }

        public virtual ICollection<RentalService> RentalServices { get; set; }
    }
}
