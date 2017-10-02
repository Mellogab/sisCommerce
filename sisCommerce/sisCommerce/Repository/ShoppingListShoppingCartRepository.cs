using sisCommerce.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace sisCommerce.Repository
{
    public class ShoppingListShoppingCartRepository
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
        private ShoppingList shopList;

        public ShoppingListShoppingCartRepository(ShoppingList shopList)
        {
            this.shopList = shopList;
        }

        public ShoppingListShoppingCartRepository()
        {

        }

        public bool insertProductShoppingList()
        {
            try
            {
                using (IDbConnection connection = new SqlConnection( ConnectionString ))
                {
                    if (connection.State == ConnectionState.Closed) connection.Open();
                    string query = "INSERT INTO shoppingList([idUser],[idProduct],[qtd]) VALUES(@IdUser, @IdProduct, 1)";
                    
                    Dictionary<string, object> dictionary = new Dictionary<string, object>();
                    dictionary.Add("@IdUser", this.shopList.idUser);
                    dictionary.Add("@IdProduct", this.shopList.idProduct);

                    var result = connection.Execute(query, new DynamicParameters(dictionary));
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}