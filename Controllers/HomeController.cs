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
        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 5;

            var newisntance = new BooksViewModel
            {
               Books = repo.Books
                .OrderBy(p => p.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

               pageInfo = new PageInfo
               {
                   TotalNumBooks = repo.Books.Count(),
                   BooksPerPage = pageSize,
                   CurrentPage = pageNum
               }
                  


            }
        }

            var inst = repo.Books.ToList()
                .OrderBy(p => p.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize);

            return View(inst);
        }


    }
}
