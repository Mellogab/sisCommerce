using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Resources;
using System.ComponentModel.DataAnnotations;

namespace sisCommerce.Models
{
    public class Users
    {

        public int id { get; set; }
        //data annotations para internacionalizar atributos da model
        [Display(Name = "Name", ResourceType = typeof(Resources.Site))]
        public string name { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public int idGroup { get; set; }
        public Users()
        {

        }

    }
}