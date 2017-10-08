using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sisCommerce.Models
{
    public class ShoppingCartViewModel
    {
        public Products Products { get; set; }
        public SaleItems SaleItems { get; set; }
    }
}