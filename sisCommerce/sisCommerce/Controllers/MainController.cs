using sisCommerce.Business;
using sisCommerce.Models;
using sisCommerce.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace sisCommerce.Controllers
{
    public class MainController : Controller
    {
        private CurrentUser cUser;
        private Groups group;
        private Users user;
        private UsersRepository uRepository;
        private GroupsRepository gRepository;
        private ProductsBusiness pBusiness;
        private ProductsController pController;

        public MainController()
        {
            user = new Users();
            group = new Groups();
            cUser = new CurrentUser().getUserSession();
            user.id = cUser.id;
            uRepository = new UsersRepository();
            pBusiness = new ProductsBusiness();
            pBusiness = new ProductsBusiness();
        }

        public Boolean validatePermissionsAdministrator()
        {
            if (cUser.id == 0 || cUser == null) return false;

            this.group.id = uRepository.findUserById(user).idGroup;
            gRepository = new GroupsRepository(this.group);
            var result = gRepository.findGroupById();
            
            if (result.name.TrimEnd() == "Administracao") {
                return true;
            }

            return false;
        }

        public Boolean validatePermissionsDefault()
        {
            if (cUser == null) return false;

            this.group.id = uRepository.findUserById(user).idGroup;
            gRepository = new GroupsRepository(this.group);
            var result = gRepository.findGroupById();

            if (result.name == "Comum")
            {
                return true;
            }

            return false;
        }

        public Boolean validatePermissionsFinancial()
        {
            if (cUser == null) return false;

            this.group.id = uRepository.findUserById(user).idGroup;
            gRepository = new GroupsRepository(this.group);
            var result = gRepository.findGroupById();

            if (result.name == "Financeiro")
            {
                return true;
            }

            return false;
        }

        [HttpPost]
        public ActionResult ChangeCurrentCulture(int language)
        {
            if (language == 0)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-br");
            }
            else if (language == 1)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us");
            }

            if(new CurrentUser().getUserSession().id == 0)
            {
                var result = pBusiness.getOnlyProducts();
                return View("../Menu/Index", result);
            }


            var prods = pBusiness.getProductsAndShoppingList();
            ViewBag.Name = new CurrentUser().getUserSession().name;

            return View("../Menu/Index", prods);
            //return pController.
        }
    }
}