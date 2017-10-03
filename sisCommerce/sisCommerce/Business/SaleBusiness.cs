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

        public SaleBusiness(SaleItems saleItems)
        {
            this.saleItems = saleItems;
        }

        public SaleBusiness()
        {
        }

        public bool AddProductToShoppingCart()
        {
            /* criar view model que irá ter o item da venda(SaleItems) e os dados de produto(Products)
             * necessário para validar quantidade disponível em estoque
             * e calcular preço total a partir da quantidade desejada pelo cliente
             */

            return false;
        }
    }
}