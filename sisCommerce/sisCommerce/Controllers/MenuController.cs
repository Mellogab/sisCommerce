using sisCommerce.Business;
using sisCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sisCommerce.Controllers
{
    public class MenuController : Controller
    {
        ProductsBusiness pBusiness;
        private MainController mController;

        public MenuController()
        {
            pBusiness = new ProductsBusiness();
            mController = new MainController();
        }

        public object getUser()
        {
            CurrentUser cUser = new CurrentUser();
            return cUser.getUserSession();
        }

        // GET: Menu
        public ActionResult Index()
        {
            if(new CurrentUser().getUserSession().id == 0)
            {
                return View(pBusiness.getOnlyProducts());
            }
            else
            {
                return View(pBusiness.getProductsAndShoppingList());
            }
            
        }

        [HttpPost]
        public ActionResult UserValidate(string username, string password)
        {
            try
            {
                Users user = new Users();
                user.user = username;
                user.password = password;

                //validar user by injection object
                UsersBusiness uBusiness = new UsersBusiness(user);
               
                var result = uBusiness.UserValidate();
                var onlyProducts = pBusiness.getOnlyProducts();

                if (result == null)
                {
                    ViewBag.Name = "Usuário/Senha incorretos";
                    return View("Index",onlyProducts);
                }

                CurrentUser cUser =
                    new CurrentUser(result.id, result.name, result.user, result.password);
                cUser.setUserSession();
                var prods = pBusiness.getProductsAndShoppingList();
                ViewBag.Name = result.name;

                return View("Index", prods);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [HttpPost]
        public ActionResult UserLoggout() {
            try
            {
                //validar user by injection object
                CurrentUser cUser = new CurrentUser();
                cUser.clearUserSession();
                var prods = pBusiness.getOnlyProducts();
                ViewBag.Name = "";
                ViewBag.Message = "Usuário Deslogado com sucesso!";
                return View("Index", prods);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public ActionResult Menu(Users user)
        {
            try
            {
                if ( getUser() != null) ViewBag.User = getUser();

                //ViewBag.Name = user.password;
                return View(user.name);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

    }
}