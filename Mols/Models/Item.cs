using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mols.Models
{
    public class Item
    {
        public int ItemId { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int StockOnHand { get; set; }

        public int StockInOrder { get; set; }

        public string Color { get; set; }

        public string ItemPictureUrl { get; set; }

        //public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}