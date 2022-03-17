using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Mission07.Infrastructure;
using Mission07.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mission07.Models
{
    //personal note, this may be inheriting wrong
    public class SessionBasket : Basket
    {
        public static Basket GetBasket(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SessionBasket basket = session?.GetJson<SessionBasket>("Basket") ?? new SessionBasket();

            basket.Session = session;

            return basket;
        }

        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(Book boo, int qty)
        {
            base.AddItem(boo, qty);
            Session.SetJson("Basket", this);
        }

        public override void RemoveItem(Book boo)
        {
            base.RemoveItem(boo);
            Session.SetJson("Basket", this);
        }

        public override void ClearBasket()
        {
            base.ClearBasket();
            Session.Remove("Basket");
        }
    }
}
