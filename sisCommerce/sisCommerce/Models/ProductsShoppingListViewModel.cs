using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sisCommerce.Models
{
    public class ProductsShoppingListViewModel
    {
        //show products in index page
        public IEnumerable<Products> Products { get; set; }
        //show wish list in navbar from index page
        public IEnumerable<ShoppingList> ShoppingList { get; set; }
    }
}