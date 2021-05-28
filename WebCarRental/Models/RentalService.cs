using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebCarRental.Models
{
    public partial class RentalService
    {
        [Display(Name = "Код прокадта")]
        public long ServicesId { get; set; }
        [Display(Name = "Дата выдачи")]
        public DateTime DateOfIssue { get; set; }
        [Display(Name = "Срок проката")]
        public string RentalPeriod { get; set; }
        [Display(Name = "Отметка об оплате")]
        public string PaymentMark { get; set; }
        [Display(Name = "Цена проката")]
        public long RentalPrice { get; set; }
        [Display(Name = "Дата возврата")]
        public DateTime ReturnDate { get; set; }
        [Display(Name = "Код автомобиля")]
        public long VehicleCode { get; set; }
        [Display(Name = "Код клиента")]
        public long ClientCode { get; set; }
        [Display(Name = "Код услуги 1")]
        public long ServiceCode1 { get; set; }
        [Display(Name = "Код услуги 2")]
        public long ServiceCode2 { get; set; }
        [Display(Name = "Код услуги 3")]
        public long ServiceCode3 { get; set; }
        [Display(Name = "Клиент")]
        public virtual Customer ClientCodeNavigation { get; set; }
        [Display(Name = "Автомобиль")]
        public virtual Car VehicleCodeNavigation { get; set; }
    }
}
