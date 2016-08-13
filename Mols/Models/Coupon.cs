using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mols.Models
{
    public class Coupon
    {
        public int CouponId { get; set; }

        public string CouponCode { get; set; }

        public bool IsActive { get; set; }

        public string CouponType { get; set; }

        public decimal CouponPercentage { get; set; }

        public decimal CouponNominal { get; set; }
    }
}