using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mols.Models
{
    public class Item
    {
        [ScaffoldColumn(false)]
        public int ItemId { get; set; }

        [DisplayName("Item Code")]
        public string ItemCode { get; set; }

        [ScaffoldColumn(false)]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [DisplayName("Item Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [DisplayName("Price")]
        public decimal Price { get; set; }

        [DisplayName("Stock On Hand")]
        public int StockOnHand { get; set; }

        [DisplayName("Stock In Order")]
        public int StockInOrder { get; set; }

        [DisplayName("Color")]
        public string Color { get; set; }

        [ScaffoldColumn(false)]
        public string ItemPictureUrl { get; set; }
    }
}