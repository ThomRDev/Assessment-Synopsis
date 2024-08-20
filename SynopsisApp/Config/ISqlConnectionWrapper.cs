using System.Data;

namespace SynopsisApp.Config
{
    // Interfaz para el envoltorio de SqlConnection
    public interface ISqlConnectionWrapper
    {
        Task OpenAsync();

        Task CloseAsync();
        ISqlCommandWrapper CreateCommand();
    }

    // Interfaz para el envoltorio de SqlCommand
    public interface ISqlCommandWrapper
    {
        void SetCommandText(string text);
        void SetCommandType(CommandType type);
        void AddParameterWithValue(string parameterName, object value);
        ISqlParameterWrapper CreateParameter();
        void AddParameter(ISqlParameterWrapper parameter);
        Task<object> ExecuteScalarAsync();
        Task<IDataReader> ExecuteReaderAsync(); // Cambiado a DbDataReader
    }

    // Interfaz para el envoltorio de SqlParameter
    public interface ISqlParameterWrapper
    {
        string ParameterName { get; set; }
        object Value { get; set; }
    }


}
