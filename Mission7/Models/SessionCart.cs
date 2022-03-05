using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Mission7.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mission7.Models
{
    public class SessionCart : Cart
    {
        public static Cart GetCart (IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SessionCart cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();
            // ^ asking if this is a new session or an old session 

            cart.Session = session;

            return cart;
        }


        // what does an ISession mean? 
        [JsonIgnore] // prevents and object from being serialized
        public ISession Session { get; set; }

        public override void AddItem(Book B, int qty)
        {
            base.AddItem(B, qty);
            Session.SetJson("Cart", this);
        }

        public override void RemoveItem(Book B)
        {
            base.RemoveItem(B);
            Session.SetJson("Cart", this);
        }

        public override void ClearCart()
        {
            base.ClearCart();
            Session.Remove("Basket");
        }
    }
}
