
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Batch4.Api.FitnessTracker.Services
{
    public class DapperService
    {
        private readonly string _connectionString;

        public DapperService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<T> Query<T>(string query,object? parms = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var lst=db.Query<T>(query,parms).ToList();
            return lst;
        }

        public T QueryFirstOrDefault<T>(string query,object? parms = null)
        {
            using IDbConnection db=new SqlConnection(_connectionString);
            var item = db.Query<T>(query,parms).FirstOrDefault();
            return item;
        }
    }
}
