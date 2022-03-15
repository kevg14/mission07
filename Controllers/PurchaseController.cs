using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mission07.Models;
using Mission07.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mission07.Controllers
{
    public class PurchaseController : Controller
    {

        private IPurchaseRepository repo { get; set; }
        private Basket basket { get; set; }

        //possible inheritance troubles
        public PurchaseController(IPurchaseRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Purchase());
        }

        [HttpPost]
        public IActionResult Checkout(Purchase cart)
        {
            if(basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry your basket is empty!");
            }

            if (ModelState.IsValid)
            {
                cart.Lines = basket.Items.ToArray();
                repo.SavePurchase(cart);
                basket.ClearBasket();

                return RedirectToPage("/PurchaseCompleted");
            }
            else
            {
                return View();
            }


        }
    }
}
