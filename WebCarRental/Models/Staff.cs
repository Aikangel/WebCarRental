using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebCarRental.Models
{
    public partial class Staff
    {
        public Staff()
        {
            Cars = new HashSet<Car>();
        }

        [Display(Name = "Код сотрудника")]
        public long EmployeeCode { get; set; }
        [Display(Name = "Телефон")]
        public long Phone { get; set; }
        [Display(Name = "Паспортные данные")]
        public long PassportDetails { get; set; }
        [Display(Name = "Адрес")]
        public string Address { get; set; }
        [Display(Name = "Пол")]
        public string Paul { get; set; }
        [Display(Name = "Возраст")]
        public long Age { get; set; }
        [Display(Name = "ФИО")]
        public string FullName { get; set; }
        [Display(Name = "Код должности")]
        public long PositionCode { get; set; }
        [Display(Name = "Должность")]
        public virtual Position PositionCodeNavigation { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
