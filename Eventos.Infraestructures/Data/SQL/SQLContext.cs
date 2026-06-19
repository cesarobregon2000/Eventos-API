using Microsoft.Data.SqlClient;
using Polly;
using System.Data;


namespace Eventos.Infraestructures.Data.SQL
{
    public class SQLContext
    {
        private readonly string _connectionString;
        private readonly IAsyncPolicy _retryPolicy;

        public SQLContext(string connectionString)
        {
            _connectionString = connectionString;

            _retryPolicy = Policy
                .Handle<SqlException>()
                .Or<TimeoutException>()
                .WaitAndRetryAsync(3, _ => TimeSpan.FromSeconds(2));
        }

        public async Task<IDbConnection> CreateConnectionAsync()
        {
            return await _retryPolicy.ExecuteAsync(async () =>
            {
                var connection = new SqlConnection(_connectionString); 
                await connection.OpenAsync();
                return connection;
            });
        }
    }
}