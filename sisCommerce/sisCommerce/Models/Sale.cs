using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sisCommerce.Models
{
    public class Sale
    {
        public int id { get; set; }
        public int idUser { get; set; }
        public float totalPrice { get; set; }
        public string method { get; set; }
        public int status { get; set; }
        public string created_at { get; set; }
        public string finished_at { get; set; }
    }
}