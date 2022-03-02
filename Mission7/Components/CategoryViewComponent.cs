using Microsoft.AspNetCore.Mvc;
using Mission7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Components
{
    public class CategoryViewComponent : ViewComponent 
    {
        private IBookstoreRepository repo { get; set; }
        public CategoryViewComponent (IBookstoreRepository temp)
        {
            repo = temp; 
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["BookCategory"];

            var category = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
            return View(category);
        }
    }
}
