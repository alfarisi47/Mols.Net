using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mols.Models;

namespace Mols.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class StoreAdminController : Controller
    {
        List<Item> _items = SampleData.ItemDummy();

        // GET: StoreAdmin
        public ActionResult Index()
        {
            return View(_items);
        }

        // GET: StoreAdmin/Details/5
        public ActionResult Details(int id)
        {
            var item = _items.Where(i => i.ItemId == id).FirstOrDefault();
            return View(item);
        }

        // GET: StoreAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StoreAdmin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StoreAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StoreAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StoreAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StoreAdmin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
