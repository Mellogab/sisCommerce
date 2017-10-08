using sisCommerce.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace sisCommerce.Business
{
    public class SaleRepository
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
        private Sale sale;
        private SaleItems saleItems;
        
        public SaleRepository(SaleItems saleItems)
        {
            this.saleItems = saleItems;
        }

        public SaleRepository()
        {
        }

        public bool addProductToShoppingCart() {
            try
            {
                using (IDbConnection connection = new SqlConnection(ConnectionString))
                {
                    if (connection.State == ConnectionState.Closed) connection.Open();
                    string query = "INSERT INTO SaleItems([idProduct],[amount],[idSale]) VALUES(@IdProduct,@Amount,@IdSale)";
                        
                    Dictionary<string, object> dictionary = new Dictionary<string, object>();
                    dictionary.Add("@IdProduct", this.saleItems.idProduct);
                    dictionary.Add("@Amount", this.saleItems.amount);
                    dictionary.Add("@IdSale", this.saleItems.idSale);
                    
                    var result = connection.Execute(query, new DynamicParameters(dictionary));
                    connection.Close();

                    this.saleItems = null;
                    return true;
                }
            }
            catch (Exception)
            {
                this.saleItems = null;
                return false;
            }
        }

        //cria a venda
        public bool createSale()
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(ConnectionString))
                {
                    if (connection.State == ConnectionState.Closed) connection.Open();
                    string query = "INSERT INTO Sale([idUser],[totalPrice],[method],[status],[created_at]) VALUES(@IdUser, 00.00,'E', 0, GETDATE())";
                    Dictionary<string, object> dictionary = new Dictionary<string, object>();
                    dictionary.Add("@IdUser", new CurrentUser().getUserSession().id);

                    var result = connection.Execute(query, new DynamicParameters(dictionary));
                    connection.Close();

                    return true;
                    
                }
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<ShoppingCart> getListShoppingCart()
        {
            List<ShoppingCart> saleItems = new List<ShoppingCart>();

            try
            {
                using (IDbConnection connection = new SqlConnection(ConnectionString))
                {
                    {
                        if (connection.State == ConnectionState.Closed) connection.Open();
                        string query = "SELECT   [SaleItems].[id] AS [idSaleItem]," +
                                                "[SaleItems].[idProduct]," +
                                                "[SaleItems].[amount]," +
                                                "[SaleItems].[idSale]," +
                                                "[Products].[name]," +
                                                "[Products].[price]," +
                                                "[Products].[quantify]," +
                                                "[Products].[image]," +
                                                "[Sale].[idUser] " +
                                       "FROM SaleItems " +
                                            " INNER JOIN Products ON([SaleItems].[idProduct] = [Products].[id])" +
                                            " INNER JOIN Sale ON([SaleItems].[idSale] = [Sale].[id])" +
                                       " WHERE[SaleItems].[idSale] = @IdSale AND [Sale].[idUser] = @IdUser";

                        Dictionary<string, object> dictionary = new Dictionary<string, object>();
                        dictionary.Add("@IdUser", new CurrentUser().getUserSession().id);
                        dictionary.Add("@IdSale", GetSaleByCurrentUser());

                        var result = connection.Query<ShoppingCart>(query, new DynamicParameters(dictionary));
                        connection.Close();

                        foreach (var item in result)
                        {
                            saleItems.Add(
                                new ShoppingCart
                                {
                                    idSaleItem = item.idSaleItem,
                                    idProduct = item.idProduct,
                                    amount = item.amount,
                                    idSale = item.idSale,
                                    name = item.name.ToString(),
                                    price = item.price,
                                    quantify = item.quantify,
                                    image = item.image.ToString(),
                                    idUser = item.idUser
                                });
                        }
                    }

                    return saleItems;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //verifica se aquele usuário possui um carrinho (venda) aberto (aberta)
        public string GetSaleByCurrentUser()
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(ConnectionString))
                {
                    if (connection.State == ConnectionState.Closed) connection.Open();
                    string query = "Select [id] From Sale Where idUser = @IdUser";

                    Dictionary<string, object> dictionary = new Dictionary<string, object>();
                    dictionary.Add("@IdUser", new CurrentUser().getUserSession().id);

                    var result = connection.QueryFirstOrDefault<Sale>(query, new DynamicParameters(dictionary));
                    connection.Close();

                    if(result != null) return Convert.ToString( result.id.ToString() );
                    return null;
                }
            }
            catch (SqlException e)
            {
                return null;
            }
        }
    }
}