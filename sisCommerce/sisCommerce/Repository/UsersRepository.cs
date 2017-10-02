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
    public class UsersRepository
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
        
        public Users findUserById(Users user)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(ConnectionString))
                {
                    if (connection.State == ConnectionState.Closed) connection.Open();
                    string query = "SELECT * FROM Users WHERE [id] = @Id ";

                    Dictionary<string, object> dictionary = new Dictionary<string, object>();
                    dictionary.Add("@Id", user.id);
                    
                    var result = connection.QueryFirstOrDefault<Users>(query, new DynamicParameters(dictionary));
                    connection.Close();

                    return result;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Users findUserByParams(Users userr)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(ConnectionString))
                {
                    if (connection.State == ConnectionState.Closed) connection.Open();
                    string query = "SELECT * FROM Users WHERE [user] = @User AND password = @Password";

                    Dictionary<string, object> dictionary = new Dictionary<string, object>();
                    dictionary.Add("@User", userr.user);
                    dictionary.Add("@Password", userr.password);

                    var result = connection.QueryFirstOrDefault<Users>(query, new DynamicParameters(dictionary));
                    connection.Close();
                    return result;
                    
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}