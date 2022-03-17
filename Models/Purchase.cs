using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Mission07.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mission07.Models
{
    public class Purchase
    {
        [Key]
        [BindNever]
        public int PurchaseId { get; set; }

        [BindNever]
        //personal note possible inheritance error
        public ICollection<BasketLineItem> Lines { get; set; }

        [Required(ErrorMessage = "Please Enter a Name: ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter an Address Line: ")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }

        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a state")]
        public string State { get; set; }

        public string Zip { get; set; }

        [Required(ErrorMessage = "Please enter a country")]
        public string Country { get; set; }

    }
}
