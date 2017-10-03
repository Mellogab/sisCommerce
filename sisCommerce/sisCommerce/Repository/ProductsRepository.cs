using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Dapper;
using sisCommerce.Models;
using System.Data;
using System.Data.SqlClient;

namespace sisCommerce.Repository
{
    public class ProductsRepository
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
        private Products prod;

        public ProductsRepository(Products prod)
        {
            this.prod = prod;
        }

        public ProductsRepository()
        {

        }

        public List<ShoppingList> getShoppingList()
        {
            List<ShoppingList> shopList = new List<ShoppingList>();
            
            try
            {
                int currentUser = new CurrentUser().getUserSession().id;

                using (IDbConnection connection = new SqlConnection(ConnectionString))
                {
                    if (connection.State == ConnectionState.Closed) connection.Open();
                    
                    string query = "SELECT [s].[qtd] as quantity_wish_user,   [s].[idProduct], [p].[name] as name, " +
                                        "  [p].[price] as price,   [p].[quantify] as quantify,   [p].[image] as image "
                      + "FROM [shoppingList] as s "
                      + " INNER JOIN [Products] as p ON ([s].[idProduct] = [p].[id])"
                      + "	WHERE [s].[idUser] = @Id";

                    Dictionary<string, object> dictionary = new Dictionary<string, object>();
                    dictionary.Add("@Id", currentUser);

                    var objects = connection.Query<ShoppingList>(query, new DynamicParameters(dictionary));
                    
                    foreach (var item in objects)
                    {
                        shopList.Add(
                            new ShoppingList
                            {
                                quantity_wish_user = item.quantity_wish_user,
                                idProduct = item.idProduct,
                                name = item.name.ToString(),
                                price = item.price,
                                quantify = item.quantify,
                                image = item.image.ToString()
                            });
                    }

                    connection.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return shopList;
        }

        public List<Products> getProducts()
        {
            List<Products> prod = new List<Products>();
            
            try
            {
                using (IDbConnection connection = new SqlConnection(ConnectionString))
                {
                    if (connection.State == ConnectionState.Closed) connection.Open();
                    string query = "SELECT [id] ,[name] ,[description] ,[price] ,[quantify] ,[image] FROM [sisCommerce].[dbo].[Products]";

                    var objects = connection.Query<Products>(query);

                    foreach (var item in objects)
                    {
                        prod.Add(
                            new Products
                            {
                                id = Convert.ToInt32(item.id),
                                name = Convert.ToString(item.name),
                                description = Convert.ToString(item.description),
                                price       = (item.price),
                                quantify    = Convert.ToInt32(item.quantify),
                                image = Convert.ToString(item.image),
                                image_base64= Convert.ToString(item.image_base64)
                            });
                    }

                        connection.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return prod;
        }

        //return product from parameter idProduct
        public Products getProductById()
        {
            Products prod;

            try
            {
                using (IDbConnection connection = new SqlConnection(ConnectionString))
                {
                    if (connection.State == ConnectionState.Closed) connection.Open();
                    string query = "SELECT * FROM [sisCommerce].[dbo].[Products] where [id] = @IdProduct";

                    Dictionary<string, object> dictionary = new Dictionary<string, object>();
                    dictionary.Add("@IdProduct", this.prod.id);
                    
                    var objects = connection.QueryFirstOrDefault<Products>(query, new DynamicParameters(dictionary));
                    connection.Close();

                    prod = new Products(){
                        id = Convert.ToInt32(objects.id),
                        name = Convert.ToString(objects.name),
                        description = Convert.ToString(objects.description),
                        price = (objects.price),
                        quantify = Convert.ToInt32(objects.quantify),
                        image = Convert.ToString(objects.image),
                        image_base64 = Convert.ToString(objects.image_base64)
                    };
                    return prod;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool insertProduct()
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(ConnectionString))
                {
                    if (connection.State == ConnectionState.Closed) connection.Open();
                    string query = "INSERT INTO Products VALUES(@name, @description, @price, @quantify, @image) ";

                    Dictionary<string, object> dictionary = new Dictionary<string, object>();
                    dictionary.Add("@name", this.prod.name );
                    dictionary.Add("@description", this.prod.description);
                    dictionary.Add("@price", this.prod.price);
                    dictionary.Add("@quantify", this.prod.quantify);
                    dictionary.Add("@image", this.prod.image_base64);
                    
                    var result = connection.Execute(query, new DynamicParameters(dictionary));
                    connection.Close();
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