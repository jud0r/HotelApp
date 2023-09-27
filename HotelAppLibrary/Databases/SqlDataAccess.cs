using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace HotelAppLibrary.Databases
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public List<T> LoadData<T, U>(string sql, U parameters, string connectionStringName, bool isStoredProcedure = false)
        {
            var connectionString = _config.GetConnectionString(connectionStringName);
            CommandType commandType = CommandType.Text;

            if (isStoredProcedure)
            {
                commandType = CommandType.StoredProcedure;
            }

            using IDbConnection connection = new SqlConnection(connectionString);
            var rows = connection.Query<T>(sql, parameters, commandType: commandType).ToList();
            return rows;
        }

        public void SaveData<T>(string sql, T parameters, string connectionStringName, bool isStoredProcedure = false)
        {
            var connectionString = _config.GetConnectionString(connectionStringName);
            CommandType commandType = CommandType.Text;

            if (isStoredProcedure)
            {
                commandType = CommandType.StoredProcedure;
            }

            using IDbConnection connection = new SqlConnection(connectionString);
            connection.Execute(sql, parameters, commandType: commandType);
        }
    }
}
