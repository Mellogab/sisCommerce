using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sisCommerce.Models
{
    public class ShoppingList
    {
        public int id { get; set; }
        public int idUser { get; set; }
        public int idProduct { get; set; }
        public int qtd { get; set; }

        public int quantity_wish_user { get; set; }
        public string name { get; set; }
        public float price { get; set; }
        public int quantify { get; set; }
        public string image { get; set; }
    }
}