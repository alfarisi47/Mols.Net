using Mols.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mols.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        List<Coupon> Coupons = SampleData.CouponDummy();
        List<Order> Orders = SampleData.OrdersDummy();

        // GET: Checkout
        public ActionResult AddressAndPayment()
        {
            return View();
        }

        //
        // POST: /Checkout/AddressAndPayment
        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var order = new Order();
            TryUpdateModel(order);
            try
            {
                Coupon coupon = Coupons.Where(c => c.CouponCode == order.CouponCode && c.IsActive).FirstOrDefault();
                if (coupon == null)
                {
                    return View(order);
                }
                else
                {
                    order.Username = User.Identity.Name;
                    order.OrderDate = DateTime.Now;
                    
                    //Save Order
                    Orders.Add(order);
                    
                    //Process the order
                    var cart = ShoppingCart.GetCart(this.HttpContext);
                    cart.CreateOrder(order);
                    return RedirectToAction("Complete", new { id = order.OrderId });
                }
            }
            catch
            {
                //Invalid - redisplay with errors
                return View(order);
            }
        }

        //
        // GET: /Checkout/Complete
        public ActionResult Complete(int id)
        {
            // Validate customer owns this order
            bool isValid = Orders.Any(o => o.OrderId == id && o.Username == User.Identity.Name);
            if (isValid)
            {
                return View(id.ToString());
            }
            else
            {
                return View("Error");
            }
        }
    }
}