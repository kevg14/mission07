using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mission07.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mission07.Components
{
    public class TypesViewComponent : ViewComponent
    {
        private IBookProjectRepository repo { get; set; }

        public TypesViewComponent (IBookProjectRepository temp)
        {
            repo = temp;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["projectType"];

            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }
    }
}
