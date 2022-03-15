using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mission07.Models.ViewModels
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public virtual void AddItem(Book boo, int qty)
        {
            BasketLineItem line = Items
                .Where(p => p.Book.BookId == boo.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Book = boo,
                    Quantity = qty,
                });
            }
            else
            {
                line.Quantity += qty; 
            }
            
        }
        //ability to delete/remove items.
        public virtual void RemoveItem(Book boo)
        {
            Items.RemoveAll(x => x.Book.BookId == boo.BookId);
        }

        public virtual void ClearBasket()
        {
            Items.Clear();
        }



        public double CalculateTotal()
        {
            //this needs to be looked at for the assignment in order to get the math right
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);

            return sum;
        }

    }

    public class BasketLineItem
    {
        [Key]
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }

    }
}
