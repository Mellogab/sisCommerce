using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sisCommerce.Models
{
    public class ShoppingCart
    {
        public int idSaleItem { get; set; }
        public int idProduct { get; set; }
        public int amount { get; set; }
        public string name { get; set; }
        public float price { get; set; }
        public int quantify { get; set; }
        public string image { get; set; }
        public int idUser { get; set; }
        public int idSale { get; set; }
    }
}