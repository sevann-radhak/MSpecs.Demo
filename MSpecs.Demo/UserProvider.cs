using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MSpecs.Demo
{
    public class UserProvider : IUserProvider
    {
        private readonly string _connectionString;

        public UserProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public User Get(int id)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<User>(
                    $"SELECT Id, Name FROM User WHERE id = {id}");
            }
        }
    }
}
