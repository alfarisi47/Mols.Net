using Mols.Models;
using Mols.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mols.Controllers
{
    public class ShoppingCartController : Controller
    {
        List<Item> Items = SampleData.ItemDummy();
        List<Cart> CartsDummy = SampleData.Carts01();

        //
        // GET: /ShoppingCart/
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            // Return the view
            return View(viewModel);
        }
        
        //
        // GET: /Store/AddToCart/5
        public ActionResult AddToCart(int id)
        {
            // Retrieve the item from dummy data
            var addedItem = Items.Single(i => i.ItemId == id);
            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart(this.HttpContext);
            cart.AddToCart(addedItem);
            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }
       
        //
        // AJAX: /ShoppingCart/RemoveFromCart/
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);
            // Get the name of the item to display confirmation
            string itemName = CartsDummy.Single(item => item.RecordId == id).Item.Name;
            // Remove from cart
            int itemCount = CartsDummy.Where(c => c.RecordId == id).Select(t => t.QtyOrder).FirstOrDefault();
            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(itemName) + " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }
        //
        // GET: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }
    }
}