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
    public class GroupsRepository
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
        private Groups group;

        public GroupsRepository(Groups groups)
        {
            group = new Groups();
            group.id = groups.id;
            group.name = groups.name;
        }

        public Groups findGroupById()
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(ConnectionString))
                {
                    if (connection.State == ConnectionState.Closed) connection.Open();
                    string query = "SELECT * FROM Groups WHERE [id] = @Id";

                    Dictionary<string, object> dictionary = new Dictionary<string, object>();
                    dictionary.Add("@Id", this.group.id);

                    var result = connection.QueryFirstOrDefault<Groups>(query, new DynamicParameters(dictionary));
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