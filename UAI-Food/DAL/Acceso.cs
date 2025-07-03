using Microsoft.Data.SqlClient;
using System.Data;

namespace DAL
{
    internal class Acceso
    {
        private readonly string? _connectionString;

        public Acceso()
        {
            _connectionString = @"Data Source=DESKTOP-CLR13LB\SQLEXPRESS; Initial Catalog=UAI-Food; Integrated Security=SSPI; TrustServerCertificate=True;";
        }

        private async Task<SqlConnection> CreateConnectionAsync()
        {
            var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            return connection;
        }

        private SqlCommand CreateCommand(string sql, SqlConnection connection, List<SqlParameter> parameters = null)
        {
            var cmd = new SqlCommand(sql, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            if (parameters != null && parameters.Count > 0)
                cmd.Parameters.AddRange(parameters.ToArray());

            return cmd;
        }
        public async Task<DataTable> GetDataAsync(string sql, List<SqlParameter> parameters = null)
        {
            try
            {
                var dataTable = new DataTable();

                using (var connection = await CreateConnectionAsync())
                using (var cmd = CreateCommand(sql, connection, parameters))
                using (var reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                {
                    dataTable.Load(reader);
                }

                return dataTable;
            }
            catch (SqlException ex)
            {
                return null;
            }
        }

        public async Task<int> ExecuteWriteAsync(string sql, List<SqlParameter> parameters = null)
        {
            using (var connection = await CreateConnectionAsync())
            using (var cmd = CreateCommand(sql, connection, parameters))
            {
                try
                {
                    return await cmd.ExecuteNonQueryAsync();
                }
                catch (SqlException ex)
                {
                    return -1;
                }
            }
        }

        public async Task<int> ExecuteWriteWithReturnAsync(string sql, List<SqlParameter> parameters = null)
        {
            using (var connection = await CreateConnectionAsync())
            using (var cmd = CreateCommand(sql, connection, parameters))
            {
                try
                {
                    var returnParam = new SqlParameter
                    {
                        ParameterName = "@ReturnCode",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.ReturnValue
                    };
                    cmd.Parameters.Add(returnParam);

                    await cmd.ExecuteNonQueryAsync();

                    return (int)(returnParam.Value ?? -3);
                }
                catch (SqlException ex)
                {
                    return -3;
                }
            }
        }


        public async Task<int> GetScalarAsync(string sql, List<SqlParameter> parameters = null)
        {
            using (var connection = await CreateConnectionAsync())
            using (var cmd = CreateCommand(sql, connection, parameters))
            {
                try
                {
                    var result = await cmd.ExecuteScalarAsync();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
                catch (SqlException)
                {
                    return -1;
                }
            }
        }

        public async Task<DateTime?> GetScalarDateTimeAsync(string sql, List<SqlParameter> parameters = null)
        {
            using (var connection = await CreateConnectionAsync())
            using (var cmd = CreateCommand(sql, connection, parameters))
            {
                try
                {
                    var result = await cmd.ExecuteScalarAsync();
                    if (result == null || result == DBNull.Value)
                        return null;

                    return Convert.ToDateTime(result);
                }
                catch
                {
                    return null;
                }
            }
        }


        public SqlParameter CreateParameter<T>(string name, T value)
        {
            var parameter = new SqlParameter
            {
                ParameterName = name,
                Value = value ?? (object)DBNull.Value
            };
            return parameter;
        }

    }
}