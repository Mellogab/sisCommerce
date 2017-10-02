using sisCommerce.Business;
using sisCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sisCommerce.Controllers
{
    public class ShoppingListShoppingCartController : Controller
    {
        private ProductsBusiness pBusiness;

        public ShoppingListShoppingCartController()
        {
            pBusiness = new ProductsBusiness();
        }
        // GET: ShoppingListShoppingCart
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertProductShoppingList(ShoppingList shopList)
        {
            try
            {
                ShoppingListShoppingCartBusiness shopListshopBusiness = new ShoppingListShoppingCartBusiness(shopList);
                shopListshopBusiness.insertProductShoppingList();

                var result = pBusiness.getProductsAndShoppingList();
                return View("../Menu/Index", result);
            }
            catch (Exception e)
            {

                throw e;
            }

           
        }
    }
}