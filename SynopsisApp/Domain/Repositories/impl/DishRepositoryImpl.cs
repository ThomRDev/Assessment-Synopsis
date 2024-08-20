using SynopsisApp.Config;
using SynopsisApp.Domain.Models;
using System.Data;

namespace SynopsisApp.Domain.Repositories.impl
{
    public class DishRepositoryImpl : DishRepository
    {

        private readonly ISqlConnectionWrapper _sqlConnectionWrapper;

        public DishRepositoryImpl(ISqlConnectionWrapper sqlConnectionWrapper)
        {
            _sqlConnectionWrapper = sqlConnectionWrapper;
        }

        public async Task<List<Dish>> GetDishes()
        {
            try
            {
                await _sqlConnectionWrapper.OpenAsync();

                var command = _sqlConnectionWrapper.CreateCommand();
                command.SetCommandText("GET_DISHES");
                command.SetCommandType(CommandType.StoredProcedure);

                var dishes = new List<Dish>();

                // Ejecutar el comando de forma asíncrona
                using (var reader = await command.ExecuteReaderAsync())
                {
                    // Leer los resultados de la consulta
                    while (reader.Read())
                    {
                        var dish = new Dish
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            Name = reader.GetString(reader.GetOrdinal("name")),
                            Description = reader.GetString(reader.GetOrdinal("description")),
                            DishPrice = reader.GetDecimal(reader.GetOrdinal("dishPrice")),
                            DishTypeId = reader.GetInt32(reader.GetOrdinal("dishTypeId")),
                            DishTypeName = reader.GetString(reader.GetOrdinal("dishTypeName"))
                        };
                        dishes.Add(dish);
                    }
                }

                return dishes;
            }
            finally
            {
                // Asegúrate de cerrar la conexión aquí
                await _sqlConnectionWrapper.CloseAsync();
            }
        }
    }
}
