using Microsoft.AspNetCore.Mvc;
using Mission7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Controllers
{
    public class PurchaseController : Controller
    {
        public PurchaseController()
        {

        }

        [HttpGet]
        public IActionResult Checkout() //checkout is the view name. 
        {
            return View(new Purchase());
        }

        [HttpPost]
        public IActionResult Checkout(Purchase purchase)
        {
           
        }



    }
}
