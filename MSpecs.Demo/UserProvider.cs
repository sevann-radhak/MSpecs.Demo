using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace MSpecs.Demo
{
    public class UserProvider : IUserProvider
    {
        private readonly string _connectionString;

        public UserProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ICollection<User> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                return connection.Query<User>(
                    $"SELECT Id, Name FROM User").ToList();
            }
        }

        public User Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<User>(
                    $"SELECT Id, Name FROM User WHERE id = {id}");
            }
        }
    }
}
