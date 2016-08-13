﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mols.Models
{
    public class SampleData
    {
        public const string Nominal = "NML";
        public const string Percentage = "PTG";
        
        public static List<Category> CategoryDummy()
        {
            var categories = new List<Category>
            {
                new Category { CategoryId = 1, CategoryName = "T-Shirt"},
                new Category { CategoryId = 2, CategoryName = "Jacket"},
                new Category { CategoryId = 3, CategoryName = "Polo Shirt"},
                new Category { CategoryId = 4, CategoryName = "Hoodie"},
            };

            return categories; 
        }


        public static List<Item> ItemDummy()
        {
            var items = new List<Item>
            {
                new Item {
                    ItemId = 1,
                    CategoryId = 1,
                    Name = "Kaos Pokemon",
                    Color = "Merah",
                    Price = 100000,
                    StockOnHand = 12,
                    StockInOrder = 0                    
                },
                new Item {
                    ItemId = 2,
                    CategoryId = 1,
                    Name = "Kaos One Piece",
                    Price = 100000,
                    StockOnHand = 12,
                    StockInOrder = 5
                },
                new Item {
                    ItemId = 3,
                    CategoryId = 2,
                    Name = "Jaket One Piece",
                    Price = 150000,
                    StockOnHand = 5,
                    StockInOrder = 0
                },
                new Item {
                    ItemId = 4,
                    CategoryId = 2,
                    Name = "Jaket Bola",
                    Price = 150000,
                    StockOnHand = 3,
                    StockInOrder = 1
                },
                new Item {
                    ItemId = 5,
                    CategoryId = 2,
                    Name = "Jaket Superman",
                    Price = 150000,
                    StockOnHand = 0,
                    StockInOrder = 0
                },
                new Item {
                    ItemId = 6,
                    CategoryId = 3,
                    Name = "Polo Shirt AS Roma",
                    Price = 100000,
                    StockOnHand = 20,
                    StockInOrder = 20
                },
                new Item {
                    ItemId = 7,
                    CategoryId = 4,
                    Name = "Hoodie Iron Man",
                    Price = 130000,
                    StockOnHand = 0,
                    StockInOrder = 0
                },
            };

            return items;
        }


        public static List<Coupon> CouponDummy()
        {
            var coupons = new List<Coupon>
            {
                new Coupon { CouponId = 1, CouponCode = "ABCDEF01", CouponType = Nominal, CouponNominal = 10000, IsActive = true},
                new Coupon { CouponId = 2, CouponCode = "ABCDEF02", CouponType = Percentage, CouponPercentage = 10, IsActive = true},
                new Coupon { CouponId = 3, CouponCode = "ABCDEF03", CouponType = Nominal, CouponNominal = 2000, IsActive = true},
                new Coupon { CouponId = 4, CouponCode = "ABCDEF04", CouponType = Nominal, CouponNominal = 15000, IsActive = true},
                new Coupon { CouponId = 5, CouponCode = "ABCDEF05", CouponType = Percentage, CouponNominal = 25, IsActive = true},
                new Coupon { CouponId = 6, CouponCode = "ABCDEF06", CouponType = Nominal, CouponNominal = 10000, IsActive = false},
            };

            return coupons;
        }
    }
}