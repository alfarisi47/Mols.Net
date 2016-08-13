using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mols.Models;

namespace Mols.Controllers
{
    public class StoreController : Controller
    {
        //
        // GET: /Store/
        public ActionResult Index()
        {
            var categories = new List<Category>
            {
                new Category { CategoryName = "T-Shirt"},
                new Category { CategoryName = "Jacket"},
                new Category { CategoryName = "Polo Shirt"}
            };
            return View(categories);
        }

        //
        // GET: /Store/Browse
        public ActionResult Browse(string categoryName)
        {
            var category = new Category { CategoryName = categoryName };
            return View(category);
        }

        //
        // GET: /Store/Details
        public ActionResult Details(int id)
        {
            var item = new Item { Name = "Item " + id };
            return View(item);
        }
    
    }
}