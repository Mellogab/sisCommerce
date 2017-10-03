using sisCommerce.Models;
using sisCommerce.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sisCommerce.Business
{
    public class ProductsBusiness
    {   
        private Products prod;
        private ProductsRepository pRepository;

        public ProductsBusiness(Products prod)
        {
            this.prod = prod;
        }

        public ProductsBusiness()
        {
        }

        public ProductsShoppingListViewModel getProductsAndShoppingList()
        {
            var productsList = getProducts();
            var shoppingList = getShoppList();

            var result = new ProductsShoppingListViewModel
            {
                Products = productsList,
                ShoppingList = shoppingList
            };

            return result;
        }

        public object getOnlyProducts()
        {
            var model = new ProductsShoppingListViewModel();
            model.Products = new ProductsRepository().getProducts();
            model.ShoppingList = null;

            return model;
        }

        public List<ShoppingList> getShoppList()
        {
            return new ProductsRepository().getShoppingList();
        }

        public List<Products> getProducts()
        {
            return new ProductsRepository().getProducts();
        }

        public Products getProductById()
        {
            return new ProductsRepository(this.prod).getProductById();
        }

        public bool insertProducts()
        {
            try
            {
                this.pRepository = new ProductsRepository(this.prod);

                if (pRepository.insertProduct())
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