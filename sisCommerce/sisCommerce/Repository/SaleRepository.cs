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

        //cria a venda
        public bool createSale()
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(ConnectionString))
                {
                    if (connection.State == ConnectionState.Closed) connection.Open();
                    string query = "INSERT INTO Sale([idUser],[totalPrice],[status],[created_at]) VALUES(@IdUser, 00.00, 0, GETDATE())";
                    Dictionary<string, object> dictionary = new Dictionary<string, object>();
                    dictionary.Add("@IdUser", new CurrentUser().getUserSession().id);

                    var result = connection.Execute(query, new DynamicParameters(dictionary));
                    connection.Close();

                    return true;
                    
                }
            }
            catch (Exception e)
            {               
                return false;
            }
        }

        //verifica se aquele usuário possui um carrinho (venda) aberto (aberta)
        public int getSaleByCurrentUser()
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

                    return result.id;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}