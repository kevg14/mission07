using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mission07.Models.ViewModels
{
    public class PageInfo : Controller
    {
        public int TotalNumBooks { get; set; }
        public int BooksPerPage { get; set; }
        public int CurrentPage {get;set;}

        //figure out how many pages we need and casting it properly
        public int TotalPages => (int) Math.Ceiling((double) TotalNumBooks / BooksPerPage) ;


    }
}
