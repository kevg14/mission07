using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mission07.Models
{
    public class EFPurchaseRepository : IPurchaseRepository
    {

        private BookstoreContext context;

        public EFPurchaseRepository(BookstoreContext temp)
        {
            context = temp;
        }


        public IQueryable<Purchase> Purchases => context.Purchases.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SavePurchase(Purchase purchase)
        {
            context.AttachRange(purchase.Lines.Select(x => x.Book));

            if(purchase.PurchaseId == 0)
            {
                context.Purchases.Add(purchase);
            }

            context.SaveChanges();
        }
    }
}
