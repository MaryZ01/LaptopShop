using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopLaptops.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name="Ім'я")]
        [StringLength(20)]
        [Required(ErrorMessage ="Довжина імені більше 20 символів")]
        public string Name { get; set; }

        [Display(Name = "Прізвище")]
        [StringLength(25)]
        [Required(ErrorMessage = "Довжина прізвища більше 25 символів")]
        public string Surname { get; set; }

        [Display(Name = "Адреса")]
        [StringLength(25)]
        [Required(ErrorMessage = "Довжина прізвища більше 25 символів")]
        public string Adress { get; set; }

        [Display(Name = "Номер телефону")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(25)]
        [Required(ErrorMessage = "Довжина номера більше 25 символів")]
        public string Phone { get; set; }

        [Display(Name = "Електронна адреса")]
        [DataType(DataType.EmailAddress)]
        [StringLength(25)]
        [Required(ErrorMessage = "Довжина електронної адреси більше 25 символів")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }

        public List<OrderDetail> Orderdetails { get; set; }
    }
}
