using sisCommerce.Business;
using sisCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sisCommerce.Controllers
{
    public class ProductsController : Controller 
    {

        private ProductsBusiness pBusiness;
        private MainController mController;
        
        public ProductsController()
        {
            pBusiness = new ProductsBusiness();
            mController = new MainController();
        }

        public CurrentUser getUser()
        {
            return new CurrentUser().getUserSession();
        }

        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products()
        {
            return View();
        }

        public ActionResult ManagerProducts()
        {
            ViewBag.Message = null;
            try
            {
                ViewBag.Message = null;
                if (getUser() != null)
                {
                    ViewBag.User = getUser();
                    ViewBag.Name = getUser().name;
                    ViewBag.User = getUser().user;
                    ViewBag.Password = getUser().password;
                }
                //validando permissao do usuário
                if (mController.validatePermissionsAdministrator()) {

                    var prods = pBusiness.getProductsAndShoppingList();
                    ViewBag.Name = new CurrentUser().getUserSession().name;

                    return View(prods);
                }
                else
                {
                    var prods = pBusiness.getProductsAndShoppingList();
                    ViewBag.Name = new CurrentUser().getUserSession().name;
                    ViewBag.Message = "Você não tem permissão para acessar esta página!";
                    return View("../Menu/Index", prods);
                    //return View("AccessDenied");
                }
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return View("AccessDenied");
            }
            
        }

        [HttpPost]
        public ActionResult InsertProducts(Products products)
        {
            var result = pBusiness.getProducts();
            ViewBag.Message = null;
            try
            {

                ProductsBusiness pBusiness = new ProductsBusiness(products);
                pBusiness.insertProducts();
                
                return View("../Products/ManagerProducts", result);
            }
            catch (Exception e)
            {

                ViewBag.Message = e.Message; 
            }

            return View("../Products/ManagerProducts", result);
        }

        public ActionResult AccessDenied()
        {
            if (getUser() != null)
            {
                ViewBag.User = getUser();
                ViewBag.Name = getUser().name;
                ViewBag.User = getUser().user;
                ViewBag.Password = getUser().password;
            }
            return View();
        }
    }
}