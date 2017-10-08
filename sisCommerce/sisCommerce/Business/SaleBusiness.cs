using sisCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sisCommerce.Business
{
    public class SaleBusiness
    {
        private SaleItems saleItems;
        private SaleRepository saleRepository;
        private Products products;
        private ProductsBusiness productsBusiness;
        private ShoppingCartViewModel shoppingCart;

        public SaleBusiness(SaleItems saleItems)
        {
            this.saleItems = saleItems;
        }

        public SaleBusiness(Products products)
        {
            this.products = products;
        }

        public SaleBusiness()
        {
        }

        public List<ShoppingCart> getListShoppingCart()
        {
            saleRepository = new SaleRepository();
            return saleRepository.getListShoppingCart();
        }

        public bool AddProductToShoppingCart()
        {
            string saleUser = "";
            saleRepository = new SaleRepository();

            var result = new ShoppingCartViewModel
            {
                Products = new ProductsBusiness(this.products).getProductById(),
                SaleItems = new SaleItems()
            };

            //verifica se o usuário possui venda aberta
            saleUser = saleRepository.GetSaleByCurrentUser();

            if (result.Products.quantify < 1){
                throw new Exception("Produto Indisponível!");
            }

            //se nâo cria uma e insere o produto em seguida
            if ( saleUser != null ) {
                result.SaleItems.idProduct = result.Products.id;
                result.SaleItems.idSale = Convert.ToInt32(saleUser);
                result.SaleItems.amount = 1;

                if (!new SaleRepository(result.SaleItems).addProductToShoppingCart())
                {
                    throw new Exception("Ops! Ocorreu um problema, tente novamente!");
                }

                return true;
            }
            
            new SaleRepository().createSale();
            saleUser = saleRepository.GetSaleByCurrentUser();
            
            //define valores no item da venda
            result.SaleItems.idProduct = result.Products.id;
            result.SaleItems.idSale = Convert.ToInt32(saleUser);
            result.SaleItems.amount = 1;

           if (!new SaleRepository(result.SaleItems).addProductToShoppingCart()) {
                throw new Exception("Ops! Ocorreu um problema, tente novamente!");
           }
            
            /* criar view model que irá ter o item da venda(SaleItems) e os dados de produto(Products)
            * necessário para validar quantidade disponível em estoque
            * e calcular preço total a partir da quantidade desejada pelo cliente
            */
             
            return true;
        }
    }
    
}