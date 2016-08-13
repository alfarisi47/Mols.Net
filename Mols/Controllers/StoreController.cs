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
        List<Category> Categories = SampleData.CategoryDummy();
        List<Item> Items = SampleData.ItemDummy();
        
        //
        // GET: /Store/
        public ActionResult Index()
        {          
            return View(Categories);
        }

        //
        // GET: /Store/Browse
        public ActionResult Browse(string categoryName)
        {
            // Retrieve Category and its Associated Items from database
            var category = Categories.Where(i => i.CategoryName == categoryName).FirstOrDefault();
            category.Items = Items.Where(i => i.CategoryId == category.CategoryId).ToList();

            return View(category);
        }

        //
        // GET: /Store/Details
        public ActionResult Details(int id)
        {
            // Retrieve Category and its Associated Items from database
            var item = Items.Where(i => i.ItemId == id).FirstOrDefault();

            return View(item);
        }

        //
        // GET: /Store/CategoriesMenu
        [ChildActionOnly]
        public ActionResult CategoriesMenu()
        {
            return PartialView(Categories.ToList());
        }
    }
}