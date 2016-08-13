using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mols.Models
{
    public partial class ShoppingCart
    {
        string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";
        IList<Cart> DummyCarts = SampleData.Carts01();
        IList<Item> Items = SampleData.ItemDummy();
        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }
        // Helper method to simplify shopping cart calls
        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }
        public void AddToCart(Item item)
        {
            // Create a new cart item if no cart item exists
            Cart cartItem = new Cart
            {
                ItemId = item.ItemId,
                CartId = ShoppingCartId,
                QtyOrder = 1,
                DateCreated = DateTime.Now
            };
            DummyCarts.Add(cartItem);

        }

        public void EmptyCart()
        {
            DummyCarts = new List<Cart>();
        }
        public List<Cart> GetCartItems()
        {
            return DummyCarts.ToList();
        }
        public int GetCount()
        {
            // Get the count of each item in the cart and sum them up
            int count = 0;

            foreach (var item in DummyCarts)
            {
                count += item.QtyOrder;
            }
            return count;
        }
        public decimal GetTotal()
        {
            //get item list
            

            decimal total = 0;
            foreach (var cart in DummyCarts)
            {
                Item item = Items.Where(i => i.ItemId == cart.ItemId).FirstOrDefault();
                total += (item.Price * cart.QtyOrder);
            }

            return total;
        }
        public int CreateOrder(Order order)
        {
            decimal orderTotal = 0;
            var cartItems = GetCartItems();
            // Iterate over the items in the cart, adding the order details for each
            foreach (var item in cartItems)
            {
                decimal price = Items.Where(i => i.ItemId == item.ItemId).Select(p => p.Price).FirstOrDefault();
                var orderDetail = new OrderDetail
                {
                    ItemId = item.ItemId,
                    OrderId = order.OrderId,
                    UnitPrice = price,
                    Quantity = item.QtyOrder
                };
                // Set the order total of the shopping cart
                orderTotal += (item.QtyOrder * price);
            }

            IList<Coupon> coupons = SampleData.CouponDummy();
            decimal discount = 0;
            if (order.CouponCode != String.Empty)
            {
                Coupon coupon = coupons.Where(c => c.CouponCode == order.CouponCode && c.IsActive).FirstOrDefault();
                if (coupon != null)
                {
                    discount = (coupon.CouponType == SampleData.Nominal ? coupon.CouponNominal : coupon.CouponPercentage * orderTotal / 100);
                }
            }
            // Set the order's total to the orderTotal count
            order.Total = orderTotal - discount;
            
            // Empty the shopping cart
            EmptyCart();
            // Return the OrderId as the confirmation number
            return order.OrderId;
        }
        // We're using HttpContextBase to allow access to cookies.
        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid classMVC Music Store Tutorial v3.0b (MVC 3 Tools Update release) – http://mvcmusicstore.codeplex.com
                    
                Guid tempCartId = Guid.NewGuid();
                    // Send tempCartId back to client as a cookie
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }
        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        public void MigrateCart(string userName)
        {
            var shoppingCart = DummyCarts.Where(c => c.CartId == ShoppingCartId);
            foreach (Cart item in shoppingCart)
            {
                item.CartId = userName;
            }
        }
    }
}