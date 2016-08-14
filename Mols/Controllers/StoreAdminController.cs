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
        List<Item> Items = SampleData.ItemDummy();
        List<Order> Orders = SampleData.OrdersDummy();

        // GET: StoreAdmin
        public ActionResult Index()
        {
            return View(Items);
        }

        // GET: StoreAdmin/Details/5
        public ActionResult Details(int id)
        {
            var item = Items.Where(i => i.ItemId == id).FirstOrDefault();
            return View(item);
        }

        // GET: StoreAdmin/Create
        public ActionResult Create()
        {
            ViewBag.ItemId = new SelectList(Items, "ItemId", "Name");
            return View();
        }

        // POST: StoreAdmin/Create
        [HttpPost]
        public ActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                Items.Add(item);
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(Items, "ItemId", "Name", item.ItemId);
            return View(item);
        }

        // GET: StoreAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            Item item = Items.Where(i => i.ItemId == id).FirstOrDefault();
            return View(item);
        }

        // POST: StoreAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                foreach (var i in Items)
                {
                    if (i.ItemId == item.ItemId)
                    {
                        i.CategoryId = item.CategoryId;
                        i.Color = item.Color;
                        i.ItemPictureUrl = item.ItemPictureUrl;
                        i.Name = item.Name;
                        i.Price = item.Price;
                        i.StockInOrder = item.StockInOrder;
                        i.StockOnHand = item.StockOnHand;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(Items, "ItemId", "Name", item.ItemId);
            return View(item);
        }

        // GET: StoreAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            Item item = Items.Where(i => i.ItemId == id).FirstOrDefault();
            return View(item);
        }

        // GET: StoreAdmin/ViewOrders
        public ActionResult ViewOrders()
        {
            return View(Orders);
        }

        // POST: StoreAdmin/ApproveOrder/1
        [HttpPost]
       public ActionResult ApproveOrder(int id)
        {
            Order order = new Order();
            foreach (var ord in Orders)
            {
                if (ord.OrderId == id)
                {
                    ord.Status = SampleData.Approved;
                }
            }
            return View(order);
        }

        // POST: StoreAdmin/RejectOrder/1
        [HttpPost]
        public ActionResult RejectOrder(int id)
        {
            Order order = new Order();
            foreach (var ord in Orders)
            {
                if (ord.OrderId == id)
                {
                    ord.Status = SampleData.Rejected;
                }
            }
            return View(order);
        }
    }
}
