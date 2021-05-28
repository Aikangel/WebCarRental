using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebCarRental.Models
{
    public partial class Car
    {
        public Car()
        {
            RentalServices = new HashSet<RentalService>();
        }

        [Display(Name = "Код автомобиля")]
        public long VehicleCode { get; set; }
        [Display(Name = "Дата последнего ТО")]
        public DateTime DateOfLastMaintenance { get; set; }
        [Display(Name = "Отметка о возврате")]
        public string ReturnMark { get; set; }
        [Display(Name = "Регистрационный номер")]
        public string RegistrationNumber { get; set; }
        [Display(Name = "Специальные отметки")]
        public string SpecialMarks { get; set; }
        [Display(Name = "Цена дня проката")]
        public long RentalDayPrice { get; set; }
        [Display(Name = "Цена автомобиля")]
        public long CarPrice { get; set; }
        [Display(Name = "Пробег")]
        public long Mileage { get; set; }
        [Display(Name = "Номер кузова")]
        public long BodyNumber { get; set; }
        [Display(Name = "Номер двигателя")]
        public string EngineNumber { get; set; }
        [Display(Name = "Год выпуска")]
        public long YearOfRelease { get; set; }
        [Display(Name = "Марка")]
        public long BrandCode { get; set; }
        [Display(Name = "Сотрудник-механик")]
        public long EmployeeCode { get; set; }

        public virtual CarBrand BrandCodeNavigation { get; set; }
        public virtual Staff EmployeeCodeNavigation { get; set; }
        public virtual ICollection<RentalService> RentalServices { get; set; }
    }
}
