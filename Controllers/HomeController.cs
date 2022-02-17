using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mission07.Models;

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
        public IActionResult Index()
        {
            var inst = repo.Books.ToList();
            return View(inst);
        }


    }
}
