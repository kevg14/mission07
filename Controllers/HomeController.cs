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
    public class HomeController : Controller
    {

        private IBookProjectRepository repo;

        public HomeController (IBookProjectRepository temp)
        {
            repo = temp;
        }


        // GET: /<controller>/
        public IActionResult Index(string categoryType, int pageNum = 1)
        {
            int pageSize = 10;

            var newinstance = new BooksViewModel
            {
                Books = repo.Books
                .Where(p => p.Category == categoryType || categoryType == null)
                .OrderBy(p => p.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                pageInfo = new PageInfo
                {
                    TotalNumBooks =
                        (categoryType == null
                        ? repo.Books.Count()
                        : repo.Books.Where(x => x.Category == categoryType).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }

            };
            return View(newinstance);
        }

    }
}
