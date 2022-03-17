using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mission07.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mission07.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Basket basket;

        public CartSummaryViewComponent(Basket bask)
        {
            basket = bask;
        }
        public IViewComponentResult Invoke()
        {
            return View(basket);
        }
    }
}
