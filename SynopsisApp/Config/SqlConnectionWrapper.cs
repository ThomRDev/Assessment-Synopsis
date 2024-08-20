using Microsoft.Data.SqlClient;
using System.Data;

namespace SynopsisApp.Config
{
    // Implementación del envoltorio de SqlConnection
    public class SqlConnectionWrapper : ISqlConnectionWrapper
    {
        private readonly SqlConnection _sqlConnection;

        public SqlConnectionWrapper(string connectionString)
        {
            _sqlConnection = new SqlConnection(connectionString);
        }

        public async Task OpenAsync()
        {
            await _sqlConnection.OpenAsync();
        }

        public async Task CloseAsync() 
        { 
            await _sqlConnection.CloseAsync();
        }

        public ISqlCommandWrapper CreateCommand()
        {
            return new SqlCommandWrapper(_sqlConnection.CreateCommand());
        }
    }

    // Implementación del envoltorio de SqlCommand
    public class SqlCommandWrapper : ISqlCommandWrapper
    {
        private readonly SqlCommand _sqlCommand;

        public SqlCommandWrapper(SqlCommand sqlCommand)
        {
            _sqlCommand = sqlCommand;
        }

        public void SetCommandText(string text)
        {
            _sqlCommand.CommandText = text;
        }

        public void SetCommandType(CommandType type)
        {
            _sqlCommand.CommandType = type;
        }

        public void AddParameterWithValue(string parameterName, object value)
        {
            _sqlCommand.Parameters.AddWithValue(parameterName, value);
        }

        public ISqlParameterWrapper CreateParameter()
        {
            return new SqlParameterWrapper(_sqlCommand.CreateParameter());
        }

        public void AddParameter(ISqlParameterWrapper parameter)
        {
            _sqlCommand.Parameters.Add(parameter as SqlParameterWrapper);
        }

        public async Task<object> ExecuteScalarAsync()
        {
            return await _sqlCommand.ExecuteScalarAsync();
        }

        public async Task<IDataReader> ExecuteReaderAsync()
        {
            return await _sqlCommand.ExecuteReaderAsync();
        }
    }

    // Implementación del envoltorio de SqlParameter
    public class SqlParameterWrapper : ISqlParameterWrapper
    {
        private readonly SqlParameter _sqlParameter;

        public SqlParameterWrapper(SqlParameter sqlParameter)
        {
            _sqlParameter = sqlParameter;
        }

        public string ParameterName
        {
            get => _sqlParameter.ParameterName;
            set => _sqlParameter.ParameterName = value;
        }

        public object Value
        {
            get => _sqlParameter.Value;
            set => _sqlParameter.Value = value;
        }

        public static implicit operator SqlParameter(SqlParameterWrapper wrapper)
        {
            return wrapper._sqlParameter;
        }
    }
}
