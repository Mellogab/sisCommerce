using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sisCommerce.Models
{
    public class SaleItems
    {
        public int id { get; set; }
        public int idProduct { get; set; }
        public int amount { get; set; }
        public int idSale { get; set; }
    }
}