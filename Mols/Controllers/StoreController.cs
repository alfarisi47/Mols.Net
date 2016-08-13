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
        List<Category> _categories = SampleData.CategoryDummy();
        List<Item> _items = SampleData.ItemDummy();
        
        //
        // GET: /Store/
        public ActionResult Index()
        {          
            return View(_categories);
        }

        //
        // GET: /Store/Browse
        public ActionResult Browse(string categoryName)
        {
            // Retrieve Category and its Associated Items from database
            var category = _categories.Where(i => i.CategoryName == categoryName).FirstOrDefault();
            category.Items = _items.Where(i => i.CategoryId == category.CategoryId).ToList();

            return View(category);
        }

        //
        // GET: /Store/Details
        public ActionResult Details(int id)
        {
            // Retrieve Category and its Associated Items from database
            var item = _items.Where(i => i.ItemId == id).FirstOrDefault();

            return View(item);
        }
    
    }
}