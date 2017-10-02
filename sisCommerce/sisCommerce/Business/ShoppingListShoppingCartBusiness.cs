using sisCommerce.Models;
using sisCommerce.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sisCommerce.Business
{
    public class ShoppingListShoppingCartBusiness
    {
        private ShoppingListShoppingCartRepository shopListsshopCart;
        private ShoppingList shopList;
        private CurrentUser cUser = new CurrentUser();

        public ShoppingListShoppingCartBusiness(ShoppingList shopList)
        {
            this.shopList = shopList;
        }

        public ShoppingListShoppingCartBusiness()
        {

        }

        public bool insertProductShoppingList()
        {
            try
            {
                this.shopList.idUser = cUser.getUserSession().id;
                shopListsshopCart = new ShoppingListShoppingCartRepository(this.shopList);

                if (shopListsshopCart.insertProductShoppingList())
                {
                    return true;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
                return false;
        }

    }
}