using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sisCommerce.Models
{
    public class CurrentUser
    {

        public CurrentUser(int id, string name , string user, string password)
        {
            this.id = id;
            this.name = name;
            this.user = user;
            this.password = password;
        }

        public CurrentUser()
        {

        }

        public int id { get; set; }
        public string name { get; set; }
        public string user { get; set; }
        public string password { get; set; }

        public void setUserSession()
        {
            HttpContext.Current.Session["id"] = this.id;
            HttpContext.Current.Session["name"] = this.name;
            HttpContext.Current.Session["user"] = this.user;
            HttpContext.Current.Session["password"] = this.password;
        }

        public void clearUserSession()
        {
            HttpContext.Current.Session.Remove("id");
            HttpContext.Current.Session.Remove("name");
            HttpContext.Current.Session.Remove("user");
            HttpContext.Current.Session.Remove("password");
        }

        public CurrentUser getUserSession()
        {
            try
            {
                CurrentUser user = new CurrentUser();

                if (HttpContext.Current.Session["id"] != null)
                {
                    user.id = Convert.ToInt32(HttpContext.Current.Session["id"]);
                    user.name = HttpContext.Current.Session["name"].ToString();
                    user.user = HttpContext.Current.Session["user"].ToString();
                    user.password = HttpContext.Current.Session["password"].ToString();                    
                }

                return user;

            }
            catch (Exception e)
            {
                throw e;
            }

        }

    }
}