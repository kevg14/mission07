using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission07.Infrastructure;
using Mission07.Models;
using Mission07.Models.ViewModels;

namespace Mission07.Pages
{
    public class AddBookModel : PageModel
    {

        private IBookProjectRepository repo { get; set; }
        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }


        public AddBookModel (IBookProjectRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }


        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";

            //basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket(); ;
        }

        public IActionResult OnPost(int bookid, string returnUrl)
        {
            Book p = repo.Books.FirstOrDefault(x => x.BookId == bookid);

            //basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();

            basket.AddItem(p, 1);

            //HttpContext.Session.SetJson("basket", basket);

            return RedirectToPage(new { ReturnUrl = returnUrl});
        }

        public IActionResult OnPostRemove (int bookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == bookId).Book);

            return RedirectToPage (new {ReturnUrl = returnUrl});
        }

    }
}
